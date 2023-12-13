using NLog;

namespace GameLogic.Model
{
    public sealed class Knight : Warrior
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Knight() : base()
        {
            HP = MaximumHP = 150;
            Name = $"ID:{ID} Knight";
            logger.Debug($"{Name} is created");
        }
    }
}
