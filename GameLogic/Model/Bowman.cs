using NLog;

namespace GameLogic.Model
{
    public sealed class Bowman : Warrior
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Bowman() : base()
        {
            HP = MaximumHP = 100;
            Name = $"ID:{ID} Bowman";
            logger.Debug($"{Name} is created");
        }
    }
}
