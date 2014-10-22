using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokermatic1000.App
{
    public enum OpponentMove
    {
        Unknown = 0 ,
        Fold  = 1 ,
        Call = 2 ,
        Bet = 3 
    }

    public enum Card
    {
        Unknown = 0,
        C2 = 2,
        C3 = 3,
        C4 = 4,
        C5 = 5,
        C6 = 6,
        C7= 7,
        C8 = 8,
        C9 = 8,
        CT = 10,
        CJ = 11,
        CQ = 12,
        CK = 13,
        CA = 14	
    }

    public sealed class Convertor
    {
        public OpponentMove ConvertToOpponentMove(string input)
        {
            var ptr = input.ToLower().Trim().ToCharArray().First();
            if (ptr == 'f')
            {
                return OpponentMove.Fold;
            }

            if (ptr == 'c')
            {
                return OpponentMove.Call;
            }
            
            if (ptr == 'b')
            {
                return OpponentMove.Bet;
            }
            return  OpponentMove.Unknown;
        }
    }
}