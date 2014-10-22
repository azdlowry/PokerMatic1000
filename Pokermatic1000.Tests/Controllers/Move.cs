using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokermatic1000.Controllers;

namespace Pokermatic1000.Tests.Controllers
{
    [TestClass]
    public class MoveTests
    {
        [TestMethod]
        public void Move_returns_call()
        {
            var controller = new HomeController();

            Assert.AreEqual("CALL", controller.Move());
        }
    }
}
