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
        public abstract void UseAbility_1();
        public abstract void UseAbility_2();
        public abstract void UseAbility_3();
        public abstract void UseAbility_4();
        public abstract void AddNewWound(int x, int y); //Change Method Signature
        public abstract event EventHandler HealthLoss;
        public abstract event EventHandler PreRaiseMoral;
        public abstract event EventHandler RaiseMoral;
        public abstract event EventHandler PreLowerMoral;
        public abstract event EventHandler LowerMoral;
        public abstract event EventHandler NoMoralChange;
    }

    public enum DamageType
    {
        Damage,
        Heal
    }
}
