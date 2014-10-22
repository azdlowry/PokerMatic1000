using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokermatic1000.App;
using Pokermatic1000.App.Strategies;

namespace Pokermatic1000.Tests.Strategies
{
    [TestClass]
    public class HighMidLowStrategyTests
    {
        [TestMethod]
        public void Ace_Bets10TimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CA);

            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void King_Bets5TimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CK);

            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void Queen_Bets3TimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CQ);

            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void Jack_BetsOnceTimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CJ);

            Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void MidCard_Calls()
        {
            var strategy = new HighMidLowStrategy(Card.C7);

            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void LowCard_Folds()
        {
            var strategy = new HighMidLowStrategy(Card.C3);

            Assert.AreEqual(strategy.Move(), OpponentMove.Fold);
        }
    }
}
