using Battleship.Controller;
using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Battleship.Model.StateMachine;
using System.Collections.Concurrent;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.View {
    internal class RemotePlayerView : IGameView {
        private BattleshipGameController controller;

        private BattleshipServer server;
        public RemotePlayerView(BattleshipGameController controller) {
            this.controller = controller;

            Action<string> consoleLogger = (msg) => {
                if (msg.Contains("Shot to (")) {
                    string[] parts = msg.Split(new char[] { '(', '/', ')' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y)) {
                        this.controller.HandlePlayerInput(new Coordinate(x, y));
                    }
                }
                Console.WriteLine(msg);
            };
            this.server = new BattleshipServer(5, consoleLogger);
        }

        public void Update(BattleshipGame game) {
            if (game.CurrentState is InitializedState) {
                server.Start();
                this.server.ClientConnected += (client) => this.server.SendMessageToClient(client, $"Current state {game.CurrentState}");
            } else {
                this.server.BroadcastMessage($"Update state {game.CurrentState}");
            }
        }
    }



    public class BattleshipServer {
        private TcpListener listener;
        private bool isRunning;
        private ConcurrentBag<TcpClient> connectedClients;
        private Action<string> logger;

        // Definieren eines Delegaten für das Event
        public delegate void ClientConnectedEventHandler(TcpClient client);

        // Das Event selbst
        public event ClientConnectedEventHandler ClientConnected;

        private void OnClientConnected(TcpClient client) {
            // Sicherstellen, dass es Abonnenten gibt
            ClientConnected?.Invoke(client);
        }

        public BattleshipServer(int port, Action<string> logger) {
            listener = new TcpListener(IPAddress.Any, port);
            this.logger = logger;
            connectedClients = new ConcurrentBag<TcpClient>();
        }

        public void Start() {
            listener.Start();
            isRunning = true;
            logger("Server gestartet und hört auf eingehende Verbindungen.");

            Task.Run(async () => {
                while (isRunning) {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    connectedClients.Add(client);
                    HandleClientAsync(client);
                }
            });
        }

        private async Task HandleClientAsync(TcpClient client) {
            logger("Client verbunden.");
            this.OnClientConnected(client);
            var stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try {
                while (isRunning && client.Connected) {
                    int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (byteCount > 0) {
                        string request = Encoding.UTF8.GetString(buffer, 0, byteCount);
                        logger("Empfangene Daten: " + request);

                        // Verarbeite die empfangenen Daten
                        // ...

                        // Optional: Sende Antwort an den Client
                        await SendMessageToClient(client, "Antwort auf " + request);
                    }
                }
            } catch (Exception e) {
                logger("Fehler bei der Kommunikation mit dem Client: " + e.Message);
            } finally {
                client.Close();
            }
        }

        public async Task BroadcastMessage(string message) {
            foreach (var client in connectedClients) {
                if (client.Connected) {
                    await SendMessageToClient(client, message);
                }
            }
        }

        public async Task SendMessageToClient(TcpClient client, string message) {
            var stream = client.GetStream();
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
        }

        public void Stop() {
            isRunning = false;
            listener.Stop();
            foreach (var client in connectedClients) {
                client.Close();
            }
            logger("Server gestoppt.");
        }
    }

}