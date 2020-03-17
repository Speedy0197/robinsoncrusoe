using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public abstract class Character
    {
        public abstract string CharacterName { get; set; }
        public abstract int CurrentHealth { get; set; }
        public abstract int MaxHealth { get; set; }
        public abstract int CurrentDetermination { get; set; }
        public abstract int[] MoraleChangeArray { get; set; }
        public abstract bool IsActiveCharacter { get; set; }


        public abstract void UseAbility_1();
        public abstract void UseAbility_2();
        public abstract void UseAbility_3();
        public abstract void UseAbility_4();
    }

    public enum DamageType
    {
        Damage,
        Heal
    }
}
