using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public class Carpenter : Character
    {
        private int actualHealthPoints;
        private int maxHealthPoints;
        private int[] moralChangeValues;
        private string characterName;
        private int moralTokens;

        public Carpenter()
        {
            characterName = "Carpenter";
            maxHealthPoints = 12;
            actualHealthPoints = maxHealthPoints;
            moralTokens = 0;
            moralChangeValues = new int[] { 4, 6, 9 };
        }

        public override void AddNewWound(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void ChangeMoralTokenValueBy(int value)
        {
            moralTokens = moralTokens + value;
            while (moralTokens < 0)
            {
                moralTokens++;
                TakePointsOfDamage(1, DamageType.Damage);
            }
        }

        public override string GetCharacterName()
        {
            return characterName;
        }

        public override int GetCurrentAmountOfMoraleTokens()
        {
            return moralTokens;
        }

        public override int GetCurrentHealth()
        {
            return actualHealthPoints;
        }

        public override int GetMaxHealth()
        {
            return maxHealthPoints;
        }

        public override bool IsPreMoralChange()
        {
            foreach (int value in moralChangeValues)
            {
                if (value == GetCurrentHealth())
                {
                    return true;
                }
            }
            return false;
        }

        public override void TakePointsOfDamage(int damage, DamageType damageType)
        {
            damage = Math.Abs(damage);
            if (damageType == DamageType.Damage)
            {
                actualHealthPoints -= damage;
                if (actualHealthPoints <= 0)
                {
                    throw new NotImplementedException();
                }
                if (CheckForMoralLoss())
                {
                    Moral.LowerMoral();
                }
            }
            else
            {
                actualHealthPoints += damage;
                if (actualHealthPoints > maxHealthPoints)
                {
                    actualHealthPoints = maxHealthPoints;
                }
            }
        }

        private bool CheckForMoralLoss()
        {
            foreach (int value in moralChangeValues)
            {
                if (value - 1 == GetCurrentHealth())
                {
                    return true;
                }
            }
            return false;
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
