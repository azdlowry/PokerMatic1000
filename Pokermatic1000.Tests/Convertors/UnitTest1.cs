using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokermatic1000.App;

namespace Pokermatic1000.Tests.Convertors
{
    [TestClass]
    public class ConvertorTest
    {
        [TestMethod]
        public void Can_be_constructed()
        {
            var convertor = new Convertor();
            Assert.IsNotNull(convertor);
        }

        [TestMethod]
        public void converts_fold_to_OPPONENT_MOVE()
        {
            var inputs = new[] { "fold", "fold ", " fold", "Fold", "FOLD" };

            foreach (var input in inputs)
            {
                var result = new Convertor().ConvertToOpponentMove(input);
                Assert.AreEqual(OpponentMove.Fold, result, "failed using " + input);
            }
        }

        [TestMethod]
        public void converts_call_to_OPPONENT_MOVE()
        {
            var inputs = new[] { "call", "call ", " call", "CALL" };

            foreach (var input in inputs)
            {
                var result = new Convertor().ConvertToOpponentMove(input);
                Assert.AreEqual(OpponentMove.Call, result, "failed using " + input);
            }
        }

        [TestMethod]
        public void converts_bet_to_OPPONENT_MOVE()
        {
            var inputs = new[] { "bet", "bet   ", " BeT", "BET" };

            foreach (var input in inputs)
            {
                var result = new Convertor().ConvertToOpponentMove(input);
                Assert.AreEqual(OpponentMove.Bet, result, "failed using " + input);
            }
        }

        
    }
}
