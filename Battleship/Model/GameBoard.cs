using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model {
    public class GameBoard {
        public int Size { get; }
        private SeaSquare[,] internalBoard;
        public GameBoard(int size) {
            this.Size = size;
            this.internalBoard = new SeaSquare[size, size];
        }
    }
}
