using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Pokermatic1000.App.Strategies
{
    public class HighMidLowStrategy
    {
        private readonly Card _ourCard;
        private bool hasBet = false;
        private Func<OpponentMove> _subStrategy;

        public HighMidLowStrategy(Card ourCard)
        {
            _ourCard = ourCard;

            if (_ourCard > Card.CT)
            {
                Trace.TraceWarning("Selecting High Strategy");
                _subStrategy = () =>
                    {
                        var nextMove = hasBet ? OpponentMove.Call : OpponentMove.Bet;
                        hasBet = true;
                        return nextMove;
                    };
            }
            else if (_ourCard > Card.C3)
            {
                Trace.TraceWarning("Selecting Mid Strategy");
                _subStrategy = () => OpponentMove.Call;
            }
            else
            {
                Trace.TraceWarning("Selecting Low Strategy");
                _subStrategy = () => OpponentMove.Fold;
            }
        }

        public OpponentMove Move()
        {
            return _subStrategy();
        }
    }
}