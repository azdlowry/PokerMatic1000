using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokermatic1000.App
{
    public enum Command
    {
        Unknown = 0 ,
        OpponentCard = 1 ,
        ReceiveChips = 2 ,
        OpponentMove = 3,
        Card = 4 ,
        PostBlind = 5 ,
        ReceiveButton = 6 


    }

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
            var ptr = GetFirstChr(input);
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

        

        public Card ConvertToCard(string input)
        {
            var ptr = GetFirstChr(input);

            if (ptr == '2') return Card.C2;
            if (ptr == '3') return Card.C3;
            if (ptr == '4') return Card.C4;
            if (ptr == '5') return Card.C5;
            if (ptr == '6') return Card.C6;
            if (ptr == '7') return Card.C7;
            if (ptr == '8') return Card.C8;
            if (ptr == '9') return Card.C9;
            if (ptr == 't') return Card.CT;
            if (ptr == 'j') return Card.CJ;
            if (ptr == 'q') return Card.CQ;
            if (ptr == 'k') return Card.CK;
            if (ptr == 'a') return Card.CA;
            return Card.Unknown;
        }

        public Command ConvertToCommand(string input)
        {
            if (String.Compare("ReceiveChips", input, true) == 0) return Command.ReceiveChips;
            if (String.Compare("Card", input, true) == 0) return Command.Card;
            if (String.Compare("OpponentCard", input, true) == 0) return Command.OpponentCard;
            if (String.Compare("OpponentMove", input, true) == 0) return Command.OpponentMove;
            if (String.Compare("PostBlind", input, true) == 0) return Command.PostBlind;
            if (String.Compare("ReceiveButton", input, true) == 0) return Command.ReceiveButton;
            if (String.Compare("ReceiveChips", input, true) == 0) return Command.ReceiveChips;

            return Command.Unknown;
        }

        private static char GetFirstChr(string input)
        {
            var ptr = input.ToLower().Trim().ToCharArray().First();
            return ptr;
        }



        internal static int ConvertToInt(string DATA)
        {
            int i;
            if (Int32.TryParse(DATA, out i))
            {
                return i;
            }
            return 0;

        }
    }
}