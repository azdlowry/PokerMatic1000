using Pokermatic1000.App.Strategies;

namespace Pokermatic1000.App
{
    public class SuddenDeathStrategy : IStrategy
    {
        public OpponentMove Move()
        {
            return OpponentMove.Fold;
        }
    }
}