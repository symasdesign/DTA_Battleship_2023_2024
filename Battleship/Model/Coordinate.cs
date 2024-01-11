namespace Battleship.Model {
    public struct Coordinate {
        public Coordinate(int x, int y) {
            this.X = x; 
            this.Y = y;
        }
        public int X {  get; }
        public int Y { get; }
    }
}
