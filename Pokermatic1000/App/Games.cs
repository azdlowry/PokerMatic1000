using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private HandLog _currentHandLog;
        private ICollection<HandLog> _previousHands = new List<HandLog>();

        public Games(string opponentName, int startingChipCount, int handLimit)
        {
            _opponentName = opponentName;
            _startingChipCount = startingChipCount;
            _handLimit = handLimit;
            _chipCount = startingChipCount;
        }

        public void Card(Card card)
        {
            UpdateHandLog();

            _strategy = new StrategyFactory()
                .Get(_opponentName, _startingChipCount, _handLimit, card, _chipCount) as HighMidLowStrategy;

            _currentHandLog = new HandLog() { OurCard = card };
        }

        public void OnOpponentCard(Card card)
        {
            _currentHandLog.OpponentCard = card;
        }

        public void OnOpponentMove(OpponentMove opponentMove)
        {
            if (opponentMove == OpponentMove.Bet) _currentHandLog.OpponentBets++;
            if (opponentMove == OpponentMove.Call) _currentHandLog.OpponentCalled = true;
            if (opponentMove == OpponentMove.Fold) _currentHandLog.OpponentFolded = true;
        }

        public void OnPostBlind()
        {
            _currentHandLog.WePostedBlind = true;
        }

        public void OnReceiveButton()
        {
            _currentHandLog.WeReceiveButton = true;
        }

        public void OnReceiveChips(int chipCount)
        {
            _chipCount = chipCount;
        }

        public void OnGameOver()
        {
            UpdateHandLog();
            // Log hands
            Trace.TraceWarning("Game over .. {0} chips remaining", _chipCount);
        }

        private void UpdateHandLog()
        {
            if (_currentHandLog != null)
            {
                Trace.TraceWarning("Last hand with {0}: {1}", _opponentName, _currentHandLog.ToString());
                _previousHands.Add(_currentHandLog);
                _currentHandLog = null;
            }
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