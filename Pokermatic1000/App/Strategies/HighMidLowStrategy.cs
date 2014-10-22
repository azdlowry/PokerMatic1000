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
        private readonly Card _lowCard;
        private readonly Card _highCard;
        private readonly Func<Card,OpponentMove> _subStrategy;
        private int _timesToBet;

        public HighMidLowStrategy(Card ourCard, int chipCount, Card lowCard = Card.C3, Card highCard = Card.C6)
        {
            _ourCard = ourCard;
            _lowCard = lowCard;
            _highCard = highCard;
            _chipCount = chipCount;
            

            if (_ourCard > _highCard)
            {
                Trace.TraceWarning("Selecting High Strategy");
                _timesToBet = GetTimesToBet(ourCard);
                _subStrategy = MaybeBet;
            }
            else if (_ourCard > _lowCard)
            {
                Trace.TraceWarning("Selecting Mid Strategy");
                _subStrategy = AllwaysCall;
            }
            else
            {
                Trace.TraceWarning("Selecting Low Strategy");
                _subStrategy = AllwaysFold;
            }

            

        }

        private  OpponentMove MaybeBet(Card ourCard)
        {
            var nextMove = _timesToBet < 1 ? OpponentMove.Call : OpponentMove.Bet;
            _timesToBet--;
            return nextMove;
        }

        private static OpponentMove AllwaysCall(Card card)
        {
            return OpponentMove.Call;
        }
        private static OpponentMove AllwaysFold(Card card)
        {
            return OpponentMove.Fold;
        }

        private int GetTimesToBet(Card ourCard)
        {
            switch (ourCard)
            {
                case Card.CA:
                    return 501;
                case Card.CK:
                    return 20;
                case Card.CQ:
                    return 7;
                case Card.CJ:
                    return 3;
                default:
                    return 1;
            }
        }

        public OpponentMove Move()
        {
            return _subStrategy(_ourCard);
        }

        public int _chipCount { get; set; }
    }
}