using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokermatic1000.App.Strategies
{
    public class HighMidLowStrategy
    {
        private readonly Card _ourCard;
        private bool hasBet = false;

        public HighMidLowStrategy(Card ourCard)
        {
            _ourCard = ourCard;
        }

        public OpponentMove Move()
        {
            if (_ourCard > Card.CT)
            {
                var nextMove = hasBet ? OpponentMove.Call : OpponentMove.Bet;
                hasBet = true;
                return nextMove;
            }
            else if (_ourCard > Card.C3)
            {
                return OpponentMove.Call;
            }
            else
            {
                return OpponentMove.Fold;
            }
        }
    }
}