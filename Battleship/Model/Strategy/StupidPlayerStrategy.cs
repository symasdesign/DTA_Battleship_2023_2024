namespace Battleship.Model.Strategy {
    public class StupidPlayerStrategy : PlayerStrategyBase {
        private Random random = new Random();
        public StupidPlayerStrategy(GameBoard board) : base(board) {
        }

        public override bool TryGetNextShot(out Coordinate target) {
            target = new Coordinate(random.Next(0, this.board.Size), random.Next(0, this.board.Size));
            return true;
        }
    }
}
