using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model.Strategy {
    public class ManualPlayerStrategy : PlayerStrategyBase {
        public ManualPlayerStrategy(GameBoard board) : base(board) {
        }
    }
}
