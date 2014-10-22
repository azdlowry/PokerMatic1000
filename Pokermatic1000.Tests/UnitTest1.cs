using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokermatic1000.App;

namespace Pokermatic1000.Tests
{
    [TestClass]
    public class GameUnitTests
    {
        [TestMethod]
        public void GameCanBeConstructed()
        {
            var game = new Games(null, 0, 0);
            Assert.IsNotNull(game);
        }

      
    }
}
