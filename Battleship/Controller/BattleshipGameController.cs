using Battleship.Model;
using Battleship.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Controller
{
    public class BattleshipGameController {
        private BattleshipGame game;
        public BattleshipGameController(BattleshipGame game) {
            this.game = game;
        }

        public void RegisterView(IGameView view) {
            this.game.RegisterView(view);
        }

        public void InitializeGame() {
            this.game.Initialize();
        }

        public void HandlePlayerInput(Coordinate coordinate) {
            this.game.HandlePlayerInput(coordinate);
        }

        public void SetPlayer1Strategy(PlayerStrategy playerStrategy) {
            this.game.SetPlayer1Strategy(playerStrategy);
        }

        public void SetPlayer2Strategy(PlayerStrategy playerStrategy) {
            this.game.SetPlayer2Strategy(playerStrategy);
        }
    }
}
