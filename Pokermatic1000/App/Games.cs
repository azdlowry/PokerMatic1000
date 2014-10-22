using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public Games(string opponentName, int startingChipCount, int handLimit)
        {
            _opponentName = opponentName;
            _startingChipCount = startingChipCount;
            _handLimit = handLimit;
        }


        internal void OnOpponentCard(Card card)
        {
            throw new NotImplementedException();
        }

        internal void OnOpponentMove(OpponentMove opponentMove)
        {
            throw new NotImplementedException();
        }

        internal void OnPostBlind()
        {
            throw new NotImplementedException();
        }

        internal void OnReceiveButton()
        {
            throw new NotImplementedException();
        }

        internal void OnReceiveChips(int p)
        {
            throw new NotImplementedException();
        }
    }
}