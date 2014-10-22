﻿using System;
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
        private readonly Card _hightCard;
        private bool hasBet = false;
        private Func<OpponentMove> _subStrategy;
        private int _timesToBet;

        public HighMidLowStrategy(Card ourCard, int chipCount, Card lowCard = Card.C3, Card hightCard = Card.CT)
        {
            _ourCard = ourCard;
            _lowCard = lowCard;
            _hightCard = hightCard;
            _chipCount = chipCount;

            if (_ourCard > _hightCard)
            {
                Trace.TraceWarning("Selecting High Strategy");
                _timesToBet = GetTimesToBet(ourCard);
                _subStrategy = () =>
                    {
                        var nextMove = _timesToBet == 0 ? OpponentMove.Call : OpponentMove.Bet;
                        hasBet = true;
                        _timesToBet--;
                        return nextMove;
                    };
            }
            else if (_ourCard > _lowCard)
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

        private int GetTimesToBet(Card ourCard)
        {
            switch (ourCard)
            {
                case Card.CA:
                    return 10;
                case Card.CK:
                    return 5;
                case Card.CQ:
                    return 3;
                case Card.CJ:
                    return 1;
                default:
                    return 0;
            }
        }

        public OpponentMove Move()
        {
            return _subStrategy();
        }

        public int _chipCount { get; set; }
    }
}