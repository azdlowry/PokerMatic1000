﻿using System;
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

        internal void Card(Card card)
        {
            if (_currentHandLog != null)
            {
                Trace.TraceWarning("Last hand: {0}", _currentHandLog.ToString());
                _previousHands.Add(_currentHandLog);
                _currentHandLog = null;
            }

            _strategy = new StrategyFactory()
                .Get(_opponentName, _startingChipCount, _handLimit, card, _chipCount) as HighMidLowStrategy;

            _currentHandLog = new HandLog() { OurCard = card };
        }

        internal void OnOpponentCard(Card card)
        {
            _currentHandLog.OpponentCard = card;
        }

        internal void OnOpponentMove(OpponentMove opponentMove)
        {
            if (opponentMove == OpponentMove.Bet) _currentHandLog.OpponentBets++;
            if (opponentMove == OpponentMove.Call) _currentHandLog.OpponentCalled = true;
            if (opponentMove == OpponentMove.Fold) _currentHandLog.OpponentFolded = true;
        }

        internal void OnPostBlind()
        {
            _currentHandLog.WePostedBlind = true;
        }

        internal void OnReceiveButton()
        {
            _currentHandLog.WeReceiveButton = true;
        }

        internal void OnReceiveChips(int p)
        {
            _chipCount = _chipCount;
        }

        internal void OnGameOver()
        {
            // Log hands
            Trace.TraceWarning("Game over .. {} chips remaining", _chipCount);
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