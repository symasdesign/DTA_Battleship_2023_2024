using Battleship.Controller;
using Battleship.Model;

namespace Battleship {
    public partial class Form1 : Form, IGameView {
        public Form1(BattleshipGameController controller) {
            InitializeComponent();
            this.gameBoardControlView1.Controller = controller;
            this.gameBoardControlView2.Controller = controller;
        }

        public void Update(BattleshipGame game) {
            if (this.InvokeRequired) {
                this.BeginInvoke(new Action(() => {
                    this.label1.Text = $"CurrentState: {game.CurrentState}";
                }));
            } else {
                this.label1.Text = $"CurrentState: {game.CurrentState}";

            }
        }
    }
}
