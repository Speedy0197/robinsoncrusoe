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
        public override int CurrentNumberOfActions { get; set; }
        public override int MaxNumberOfActions { get; set; }
        public override bool IsDead { get; set; } = false;
        public Explorer()
        {
            CharacterName = "Explorer";
            MaxHealth = 11;
            CurrentHealth = MaxHealth;
            CurrentDetermination = 0;
            MoraleChangeArray = new int[] { 2, 7 };
            IsActiveCharacter = false;
            MaxNumberOfActions = 2;
            CurrentNumberOfActions = MaxNumberOfActions;
        }
        public override void UseAbility()
        {
            if(CurrentDetermination >= GetAbilityCosts())
            {
                //Motivational Speech
                CharacterActions.LowerCharacterDeterminationBy(GetAbilityCosts(), this);
                Moral.RaiseMoral();
            }
        }

        public override int GetAbilityCosts()
        {
            return 3;
        }

        public override string GetAbilityDescription()
        {
            return "Erhöhe die Gruppenmoral um 1";
        }
    }
}
