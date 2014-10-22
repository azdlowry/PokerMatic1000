using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokermatic1000.App.Strategies
{
    
    public class StrategyFactory
    {
        public object Get(string opponentName, int startingChipCount, int handLimit, Card ourCard, int chipCount)
        {
            return new HighMidLowStrategy(ourCard, chipCount);
        }
    }
}