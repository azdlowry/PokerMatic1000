using System.Diagnostics;
using Pokermatic1000.App.Strategies;

namespace Pokermatic1000.App
{
    public class SuddenDeathStrategy : IStrategy
    {
        public SuddenDeathStrategy()
        {

            Trace.TraceWarning("Selecting SuddenDeathStrategy");
        }

        public OpponentMove Move()
        {
            return OpponentMove.Fold;
        }
    }
}