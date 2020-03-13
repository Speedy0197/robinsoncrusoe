using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public abstract class Character
    {
        public abstract void TakePointsOfDamage(int damage, DamageType damageType);
        public abstract string GetCharacterName();
        public abstract int GetCurrentHealth();
        public abstract int GetMaxHealth();
        public abstract void UseAbility_1();
        public abstract void UseAbility_2();
        public abstract void UseAbility_3();
        public abstract void UseAbility_4();
        public abstract void AddNewWound(int x, int y); //Change Method Signature
        public abstract void ChangeMoralTokenValueBy(int value);
        public abstract int GetCurrentAmountOfMoraleTokens();
        public abstract bool IsPreMoralChange();
    }

    public enum DamageType
    {
        Damage,
        Heal
    }
}
