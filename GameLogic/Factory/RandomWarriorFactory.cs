using GameLogic.Interface;
using GameLogic.Model;

namespace GameLogic.Factory
{
    internal sealed class RandomWarriorFactory : IWarriorFactory
    {
        private Random random = new Random();

        public Warrior CreateWarrior()
        {
            int randomNumber = random.Next(3);

            switch (randomNumber)
            {
                case 0:
                    return new Swordsman();
                case 1:
                    return new Archer();
                case 2:
                    return new Knight();
                default:
                    throw new InvalidOperationException("Unexpected value.");
            }
        }
    }

}
