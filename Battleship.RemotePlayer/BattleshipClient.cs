using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Battleship.RemotePlayer {


    public class BattleshipClient {
        private TcpClient client;
        private NetworkStream stream;
        private CancellationTokenSource cancellationTokenSource;
        private Action<string> logger;

        public BattleshipClient(Action<string> logger) {
            this.logger = logger;
            client = new TcpClient();
            cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task ConnectAsync(string ip, int port) {
            try {
                await client.ConnectAsync(ip, port);
                logger("Mit Server verbunden.");
                stream = client.GetStream();

                Task.Run(() => ListenForMessages(cancellationTokenSource.Token));
            } catch (Exception e) {
                logger("Fehler bei der Verbindung: " + e.Message);
            }
        }

        public bool IsConnected {
            get {
                return this.client.Connected;
            }
        }
        private async Task ListenForMessages(CancellationToken cancellationToken) {
            byte[] buffer = new byte[1024];

            try {
                while (!cancellationToken.IsCancellationRequested) {
                    int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                    if (byteCount > 0) {
                        string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                        logger("Vom Server empfangen: " + message);
                    }
                }
            } catch (Exception e) {
                if (!cancellationToken.IsCancellationRequested) {
                    logger("Fehler beim Empfangen der Nachrichten: " + e.Message);
                }
            }
        }

        public async Task SendAsync(string message) {
            if (!client.Connected) {
                logger("Client ist nicht mit dem Server verbunden.");
                return;
            }

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
            logger("Nachricht gesendet: " + message);
        }

        public void Disconnect() {
            cancellationTokenSource.Cancel();
            stream?.Close();
            client?.Close();
            logger("Verbindung zum Server getrennt.");
        }
    }

}
