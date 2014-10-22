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
        public void Ace_Bets501TimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CA,1);
            MakeBet(strategy,501);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }
             

        [TestMethod]
        public void King_Bets10TimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CK,1);

            MakeBet(strategy, 10);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void Queen_BetsFiveTimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CQ,1);

            MakeBet(strategy, 5);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void Jack_BetsThreeTimesThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CJ,1);

            MakeBet(strategy, 3);
            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void HiCard_Bets()
        {
            var strategy = new HighMidLowStrategy(Card.CT, 1);
            var actual = strategy.Move();
            Assert.AreEqual(OpponentMove.Bet, actual);
        }

        [TestMethod]
        public void MidCard_Calls()
        {
            var strategy = new HighMidLowStrategy(Card.C7, 1);

            Assert.AreEqual(strategy.Move(), OpponentMove.Call);
        }

        [TestMethod]
        public void LowCard_Folds()
        {
            var strategy = new HighMidLowStrategy(Card.C3,1);

            Assert.AreEqual(strategy.Move(), OpponentMove.Fold);
        }

        private static void MakeBet(HighMidLowStrategy strategy, int calls = 1)
        {
            for (var i = 0; i < calls; i++)
            {
                Assert.AreEqual(strategy.Move(), OpponentMove.Bet);
            }
        }
    }
}
