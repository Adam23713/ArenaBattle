using NLog;

namespace GameLogic.Model
{
    public sealed class Horseman : Warrior
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Horseman() : base()
        {
            HP = MaximumHP = 150;
            Name = $"ID:{ID} Horseman";
            logger.Debug($"{Name} is created");
        }
    }
}
