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

        public Games(string opponentName, int startingChipCount, int handLimit)
        {
            _opponentName = opponentName;
            _startingChipCount = startingChipCount;
            _handLimit = handLimit;
        }

        internal void Card(Card card)
        {
            _strategy = new HighMidLowStrategy(card);
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
        }

        internal OpponentMove GetMove()
        {
            return OpponentMove.Call; ;
        }

        internal void Card(Card card)
        {
            throw new NotImplementedException();
        }
    }
}