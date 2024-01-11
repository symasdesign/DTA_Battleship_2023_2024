using Battleship.Model.StateMachine;
using Battleship.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model {
    public class BattleshipGame {
        private IBattleshipGameState currentState;
        public GameBoard Player1Board { get; set; }
        public GameBoard Player2Board { get; set; }

        public PlayerStrategyBase Player1Strategy { get; private set; } 
        public PlayerStrategyBase Player2Strategy { get; private set; } 

        public void SetPlayer1Strategy(PlayerStrategy playerStrategy) {
            this.Player1Strategy = PlayerStrategyFactory.Create(playerStrategy, this.Player1Board);
        }
        public void SetPlayer2Strategy(PlayerStrategy playerStrategy) {
            this.Player2Strategy = PlayerStrategyFactory.Create(playerStrategy, this.Player1Board);
        }

        public BattleshipGame() {
            this.SetPlayer1Strategy(PlayerStrategy.Manual);
            this.SetPlayer2Strategy(PlayerStrategy.Manual);

            TransitionToState(new UninitializedState());
        }

        public void Initialize() {
            TransitionToState(new InitializedState());
        }

        public IBattleshipGameState CurrentState {
            get {
                return this.currentState;
            }
        }
        public void TransitionToState(IBattleshipGameState newState) {
            Debug.WriteLine($"Transition from {this.currentState} to {newState}");

            this.currentState?.ExitState(this);
            this.currentState = newState;
            newState.EnterState(this);
            this.NotifyObservers();
            newState.AfterEnterState(this);
        }

        private List<IGameView> gameObservers = new List<IGameView>();
        public void RegisterView(IGameView view) {
            this.gameObservers.Add(view);
        }
        public void UnregisterView(IGameView view) {
            if (this.gameObservers.Contains(view)) {
                this.gameObservers.Remove(view);
            }
        }
        private void NotifyObservers() {
            foreach (var observer in this.gameObservers) {
                observer.Update(this);
            }
        }

        public void HandlePlayerInput(Coordinate coordinate) {
            this.currentState.HandleInput(this, coordinate);
        }
    }
}
