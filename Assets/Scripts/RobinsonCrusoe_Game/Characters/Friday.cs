using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public class Friday : Character, ISideCharacter
    {
        public override string CharacterName { get; set; }
        public override int CurrentHealth { get; set; }
        public override int MaxHealth { get; set; }
        public override int CurrentDetermination { get; set; }
        public override int[] MoraleChangeArray { get; set; }
        public override bool IsActiveCharacter { get; set; }
        public override int CurrentNumberOfActions { get; set; }
        public override int MaxNumberOfActions { get; set; }
        public override bool IsDead { get; set; } = false;
        public Friday()
        {
            CharacterName = "Friday";
            MaxHealth = 3;
            CurrentHealth = MaxHealth;
            CurrentDetermination = 0;
            MoraleChangeArray = null;
            IsActiveCharacter = false;
            MaxNumberOfActions = 1;
            CurrentNumberOfActions = MaxNumberOfActions;
        }

        public override void UseAbility_1()
        {
            return;
        }

        public override void UseAbility_2()
        {
            return;
        }

        public override void UseAbility_3()
        {
            return;
        }

        public override void UseAbility_4()
        {
            return;
        }
    }
}
