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
        public void HighCard_BetsOnceThenCalls()
        {
            var strategy = new HighMidLowStrategy(Card.CA);

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
