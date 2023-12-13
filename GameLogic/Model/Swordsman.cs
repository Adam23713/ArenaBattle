using NLog;

namespace GameLogic.Model
{
    public sealed class Swordsman : Warrior
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Swordsman() : base()
        {
            HP = MaximumHP = 120;
            Name = $"ID:{ID} Swordsman";
            logger.Debug($"{Name} is created");
        }
    }
}
