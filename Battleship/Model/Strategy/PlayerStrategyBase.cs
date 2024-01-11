using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model.Strategy {
    public abstract class PlayerStrategyBase {
        protected GameBoard board;
        protected PlayerStrategyBase(GameBoard board) {
            this.board = board;
        }
        public virtual bool TryGetNextShot(out Coordinate target) {
            target = default;
            return false;
        }


    }
}
