using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public class Explorer : Character
    {
        public override string CharacterName { get; set; }
        public override int CurrentHealth { get; set; }
        public override int MaxHealth { get; set; }
        public override int CurrentDetermination { get; set; }
        public override int[] MoraleChangeArray { get; set; }
        public override bool IsActiveCharacter { get; set; }

        public Explorer()
        {
            CharacterName = "Explorer";
            MaxHealth = 11;
            CurrentHealth = MaxHealth;
            CurrentDetermination = 0;
            MoraleChangeArray = new int[] { 2, 7 };
            IsActiveCharacter = false;
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
