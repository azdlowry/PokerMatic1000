using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pokermatic1000.App;

namespace Pokermatic1000.Controllers
{
    public class HomeController : Controller
    {
        public static Games CurrentGame;
        public static Convertor Convertor = new Convertor();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public object Start(string OPPONENT_NAME, int STARTING_CHIP_COUNT, int HAND_LIMIT)
        {
            Trace.TraceInformation("Start({0}, {1}, {2})", OPPONENT_NAME, STARTING_CHIP_COUNT, HAND_LIMIT);
            CurrentGame = new Games(OPPONENT_NAME, STARTING_CHIP_COUNT, HAND_LIMIT);
            return null;
        }

        [HttpGet]
        public object Move()
        {
            var rtn = CurrentGame.GetMove().ToString().ToUpper();
            Trace.TraceInformation("Move <- {0}", rtn);
            return rtn;
        }

        [HttpPost]
        public object Update(string COMMAND, string DATA)
        {
            Trace.TraceInformation("Update({0}, {1})", COMMAND, DATA);
            var cmd = Convertor.ConvertToCommand(COMMAND);
            switch (cmd)
            {
                case Command.Card:
                    CurrentGame.Card(Convertor.ConvertToCard(DATA));
                    break;

                case Command.OpponentCard:
                    CurrentGame.OnOpponentCard(Convertor.ConvertToCard(DATA));
                    break;

                case Command.OpponentMove:
                    CurrentGame.OnOpponentMove(Convertor.ConvertToOpponentMove(DATA));
                    break;

                case Command.PostBlind:
                    CurrentGame.OnPostBlind();
                    break;

                case Command.ReceiveButton:
                    CurrentGame.OnReceiveButton();
                    break;
                case Command.ReceiveChips:
                    CurrentGame.OnReceiveChips(Convertor.ConvertToInt(DATA));
                    break;
                case Command.GameOver:
                    CurrentGame.OnGameOver();
                    break;
                case Command.Unknown:

                    break;
            }


            return null;
        }
    }
}
