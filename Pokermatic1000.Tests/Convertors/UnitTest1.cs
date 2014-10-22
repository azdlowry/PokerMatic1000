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

        [TestMethod]
        public void converts_card_to_CARD()
        {
            var inputs = new Dictionary<string, Card>();
            inputs["2"] = Card.C2;
            inputs[" 2"] = Card.C2;
            inputs["3"] = Card.C3;
            inputs["3 "] = Card.C3;
            inputs["4"] = Card.C4;
            inputs["5"] = Card.C5;
            inputs["6"] = Card.C6;
            inputs["7"] = Card.C7;
            inputs["8"] = Card.C8;
            inputs["9"] = Card.C9;
            inputs["t"] = Card.CT;
            inputs["T"] = Card.CT;
            inputs["j"] = Card.CJ;
            inputs["q"] = Card.CQ;
            inputs["Q"] = Card.CQ;
            inputs["k"] = Card.CK;
            inputs["a"] = Card.CA;





            foreach (var input in inputs.Keys)
            {
                var result = new Convertor().ConvertToCard(input);
                Assert.AreEqual(inputs[input], result, "failed using " + input);
            }


        }

        
    }
}
