using System;
using Pokermatic1000.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pokermatic1000.Tests.Game
{
    [TestClass]
    public class GameTestss
    {
        [TestMethod]
        public void CanBeConstructed()
        {
            var g = new Games("", 1, 1);
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void CanRunAGame()
        {
            var g = new Games("", 1, 1);
            g.Card(Card.CT);
            g.OnReceiveButton();
            g.GetMove();
            g.OnOpponentMove(OpponentMove.Fold);
            g.OnReceiveChips(2);
            g.OnPostBlind();
            g.GetMove();
            g.OnOpponentMove(OpponentMove.Call);
            g.GetMove();
            g.OnOpponentMove(OpponentMove.Call);
            g.GetMove();
            g.OnOpponentMove(OpponentMove.Call);
        }
    }
}
