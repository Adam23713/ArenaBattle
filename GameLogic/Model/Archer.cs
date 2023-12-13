using NLog;

namespace GameLogic.Model
{
    public sealed class Archer : Warrior
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Archer() : base()
        {
            HP = MaximumHP = 100;
            Name = $"ID:{ID} Archer";
            logger.Debug($"{Name} is created");
        }
    }
}
