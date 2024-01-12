using Battleship.Model;
using Battleship.Model.StateMachine;

namespace Battleship.Tests {
    [TestClass]
    public class BattleshipGameTests {
        [TestMethod]
        public void TestInitialization() {
            // AAA

            // Arrange
            var game = new BattleshipGame();

            // Act
            game.Initialize();

            // Assert
            Assert.IsInstanceOfType(game.CurrentState, typeof(Players1TurnState), "State should be initialized.");
        }

        [TestMethod]
        public void TestPlayers1Turn() {

        }
    }
}