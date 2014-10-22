using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pokermatic1000.App.Strategies;

namespace Pokermatic1000.App
{
    public interface IGames
    {
    }

    public class Games : IGames
    {
        private string _opponentName;
        private int _startingChipCount;
        private int _handLimit;
        private HighMidLowStrategy _strategy;
        private int _chipCount;

        public Games(string opponentName, int startingChipCount, int handLimit)
        {
            _opponentName = opponentName;
            _startingChipCount = startingChipCount;
            _handLimit = handLimit;
            _chipCount = startingChipCount;
        }

        internal void Card(Card card)
        {
            _strategy = new StrategyFactory()
                .Get(_opponentName,_startingChipCount,_handLimit,card) as HighMidLowStrategy;
        }

        internal void OnOpponentCard(Card card)
        {
        }

        internal void OnOpponentMove(OpponentMove opponentMove)
        {
        }

        internal void OnPostBlind()
        {
        }

        internal void OnReceiveButton()
        {
        }

        internal void OnReceiveChips(int p)
        {
            _chipCount = _chipCount;
        }

        internal OpponentMove GetMove()
        {
            if (_strategy == null)
            {
                return OpponentMove.Call;
            }
            else
            {
                var rtn = _strategy.Move();
                if (rtn == OpponentMove.Bet)
                {
                    _chipCount--;
                }
                return rtn;
            }
        }
    }
}