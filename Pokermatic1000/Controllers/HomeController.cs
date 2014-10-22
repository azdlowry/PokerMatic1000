using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokermatic1000.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public object Start(string OPPONENT_NAME, int STARTING_CHIP_COUNT, int HAND_LIMIT)
        {

            return null;
        }

        [HttpGet]
        public object Move()
        {

            return "CALL";
        }

        [HttpPost]
        public object Update(string COMMAND, string DATA)
        {
            return null;
        }
    }
}
