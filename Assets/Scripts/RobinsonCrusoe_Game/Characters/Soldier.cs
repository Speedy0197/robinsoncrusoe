using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public class Soldier : Character
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
        public Soldier()
        {
            CharacterName = "Soldier";
            MaxHealth = 11;
            CurrentHealth = MaxHealth;
            CurrentDetermination = 0;
            MoraleChangeArray = new int[] { 4, 8 };
            IsActiveCharacter = false;
            MaxNumberOfActions = 2;
            CurrentNumberOfActions = MaxNumberOfActions;
        }
        public override void UseAbility()
        {
            if(CurrentDetermination >= GetAbilityCosts())
            {
                //Defense Plan
                CharacterActions.LowerCharacterDeterminationBy(GetAbilityCosts(), this);
                WeaponPower.RaiseWeaponPowerBy(1);
            }
        }

        public override int GetAbilityCosts()
        {
            return 2;
        }
    }
}
