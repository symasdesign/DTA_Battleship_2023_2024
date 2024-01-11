using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model.Strategy {
    public static class PlayerStrategyFactory {
        public static PlayerStrategyBase Create(PlayerStrategy strategy, GameBoard board) {
            switch (strategy) {
                case PlayerStrategy.Manual:
                    return new ManualPlayerStrategy(board);
                case PlayerStrategy.Stupid:
                    return new StupidPlayerStrategy(board);
                //case PlayerStrategy.Smart:
                //    return new SmartPlayerStrategy(board);
                //case PlayerStrategy.Genius:
                //    return new GeniusPlayerStrategy(board);
                //case PlayerStrategy.Expert:
                //    return new ExpertPlayerStrategy(board);
                default:
                    throw new UnknownPlayerStrategyException();
            }
        }
    }
}
