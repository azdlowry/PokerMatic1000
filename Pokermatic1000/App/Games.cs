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

        //     private HandLog currentHandLog;
        //   private ICollection<HandLog> previousHands;

        public Games(string opponentName, int startingChipCount, int handLimit)
        {
            _opponentName = opponentName;
            _startingChipCount = startingChipCount;
            _handLimit = handLimit;
            _chipCount = startingChipCount;
        }

        public void Card(Card card)
        {
            _strategy = new StrategyFactory()
                .Get(_opponentName, _startingChipCount, _handLimit, card, _chipCount) as HighMidLowStrategy;
        }

        public void OnOpponentCard(Card card)
        {
        }

        public void OnOpponentMove(OpponentMove opponentMove)
        {
        }

        public void OnPostBlind()
        {
        }

        public void OnReceiveButton()
        {
        }

        public void OnReceiveChips(int p)
        {
            _chipCount = _chipCount;
        }

        public OpponentMove GetMove()
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