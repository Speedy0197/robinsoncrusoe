using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public class Cook : Character
    {
        private int actualHealthPoints;
        private int maxHealthPoints;
        private string characterName;
        private int[,] wounds; //Change Datatype

        public Cook()
        {
            characterName = "Cook";
            maxHealthPoints = 12;
            actualHealthPoints = 12;
        }

        public override event EventHandler HealthLoss;

        public override void AddNewWound(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override string GetCharacterName()
        {
            return characterName;
        }

        public override int GetCurrentHealth()
        {
            return actualHealthPoints;
        }

        public override void TakePointsOfDamage(int damage)
        {
            actualHealthPoints -= damage;
            if(actualHealthPoints <= 0)
            {
                throw new NotImplementedException();
            }
            if(actualHealthPoints > maxHealthPoints)
            {
                actualHealthPoints = maxHealthPoints;
            }
            HealthLoss?.Invoke(this, new EventArgs());
        }

        public override void UseAbility_1()
        {
            throw new NotImplementedException();
        }

        public override void UseAbility_2()
        {
            throw new NotImplementedException();
        }

        public override void UseAbility_3()
        {
            throw new NotImplementedException();
        }

        public override void UseAbility_4()
        {
            throw new NotImplementedException();
        }
    }
}
