

namespace GameLogic.Model
{
    public abstract class Warrior
    {
        private static int warriorCounter = 0;
        private bool dead;
        private float hp;

        public int ID { get; protected set; }

        public bool Dead 
        {
            get { return dead; }
            set 
            {
                dead = value;
                if (dead)
                {
                    hp = 0;
                }
            } 
        }

        public float HP 
        {
            get { return hp; } 
            set
            {
                if(value > MaximumHP)
                {
                    hp = MaximumHP;
                }
                else if (value < 0)
                {
                    hp = 0;
                    dead = true;
                }
                else
                { 
                    hp = value;
                }
            }
        }

        public int MaximumHP { get; protected set; }

        public string Name { get; protected set; }

        public Warrior() 
        {
            dead = false;
            ID = ++warriorCounter;
        }

        public void AddHpPoints(int value)
        {
            if (hp == MaximumHP) return;

            if (hp + value > MaximumHP)
            {
                hp = MaximumHP;
            }
            else if(hp + value < 0) //if value is minus
            {
                hp = 0;
                dead = true;
            }
            else 
            { 
                hp += value;
            }
        }
    }
}
