using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model.StateMachine {
    public class Players1TurnState : PlayersTurnState {
        public override void EnterState(BattleshipGame game) {
            base.EnterState(game);
            Debug.WriteLine("Enter Players1TurnState");

            var strategy = game.Player1Strategy;
            if (strategy.TryGetNextShot(out Coordinate target))            {
                this.HandleInput(game, target);
            }
        }

        public override void HandleInput(BattleshipGame game, Coordinate coordinate) {
            // Input behandeln (Getroffen, ja/nein)

            // entsprechend State ändern

            if (coordinate.X == 2 && coordinate.Y == 2) {
                // Treffer
                game.TransitionToState(new Players1TurnState());
            } else {
                game.TransitionToState(new Players2TurnState());

            }
        }
    }
}
