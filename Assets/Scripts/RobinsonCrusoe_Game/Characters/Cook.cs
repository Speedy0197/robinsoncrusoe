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
        public override event EventHandler PreRaiseMoral;
        public override event EventHandler RaiseMoral;
        public override event EventHandler PreLowerMoral;
        public override event EventHandler LowerMoral;
        public override event EventHandler NoMoralChange;

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

        public override void TakePointsOfDamage(int damage, DamageType damageType)
        {
            damage = Math.Abs(damage);
            if (damageType == DamageType.Damage) actualHealthPoints -= damage;
            else actualHealthPoints += damage;

            if(actualHealthPoints <= 0)
            {
                throw new NotImplementedException();
            }
            if(actualHealthPoints > maxHealthPoints)
            {
                actualHealthPoints = maxHealthPoints;
            }

            CheckForMoralChange(damageType);

            HealthLoss?.Invoke(this, new EventArgs());
        }

        private void CheckForMoralChange(DamageType type)
        {
            if(type == DamageType.Damage)
            {
                if (actualHealthPoints == 10 ||
                    actualHealthPoints == 7 ||
                    actualHealthPoints == 5 ||
                    actualHealthPoints == 3)
                {
                    PreLowerMoral?.Invoke(null, new EventArgs());
                    return;
                }
    
                if (actualHealthPoints == 9 ||
                    actualHealthPoints == 6 ||
                    actualHealthPoints == 4 ||
                    actualHealthPoints == 2)
                {
                    LowerMoral?.Invoke(null, new EventArgs());
                    PreRaiseMoral?.Invoke(null, new EventArgs());
                    return;
                }
                NoMoralChange?.Invoke(null, new EventArgs());
            }
            else
            {
                if (actualHealthPoints == 9 ||
                    actualHealthPoints == 6 ||
                    actualHealthPoints == 4 ||
                    actualHealthPoints == 2)
                {
                    PreRaiseMoral?.Invoke(null, new EventArgs());
                    return;
                }

                if (actualHealthPoints == 10 ||
                    actualHealthPoints == 7 ||
                    actualHealthPoints == 5 ||
                    actualHealthPoints == 3)
                {
                    RaiseMoral?.Invoke(null, new EventArgs());
                    PreLowerMoral?.Invoke(null, new EventArgs());
                    return;
                }
                NoMoralChange?.Invoke(null, new EventArgs());
            }
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
