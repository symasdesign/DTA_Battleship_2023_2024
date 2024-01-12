namespace Battleship.RemotePlayer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.lblLog.Text = "";
        }

        private BattleshipClient client;
        private async void btnConnect_Click(object sender, EventArgs e) {
            this.client = new BattleshipClient(WriteMessage);
            await this.client.ConnectAsync(this.textBox1.Text, 5);
            if (this.client.IsConnected) {
                this.btnShot.Enabled = true;
            }
        }
        private void WriteMessage(string msg) {
            this.BeginInvoke(new Action(() => {
                this.lblLog.Text += msg + "\n";
            }));
        }

        private void btnShot_Click(object sender, EventArgs e) {
            this.client.SendAsync($"Shot to ({this.numX.Value}/{this.numY.Value})");
        }
    }
}
