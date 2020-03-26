using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public static class CharacterActions
    {
        public static void DamageCharacterBy(int amount, Character character)
        {
            if (amount < 0) amount = 0;
            character.CurrentHealth -= amount;
            if (character.CurrentHealth <= 0)
            {
                //Character Death
                throw new NotImplementedException();
            }
            if (CheckForMoralLoss(character))
            {
                Moral.LowerMoral();
            }

        }
        private static bool CheckForMoralLoss(Character character)
        {
            foreach (int value in character.MoraleChangeArray)
            {
                if (value - 1 == character.CurrentHealth)
                {
                    return true;
                }
            }
            return false;
        }

        public static void HealCharacterBy(int amount, Character character)
        {
            if (amount < 0) amount = 0;
            character.CurrentHealth += amount;
            if (character.CurrentHealth > character.MaxHealth)
            {
                character.CurrentHealth = character.MaxHealth;
            }
        }
        public static void WoundCharacter(int wound, Character character) //TODO: find a good way to handle the different wounds
        {
            throw new NotImplementedException("No Code for character wounding");
        }
        public static void LowerCharacterDeterminationBy(int amount, Character character)
        {
            if (amount < 0) amount = Math.Abs(amount);

            if (character is ISideCharacter)
            {
                DamageCharacterBy(amount, character);
            }
            else
            {
                character.CurrentDetermination -= amount;

                while (character.CurrentDetermination < 0)
                {
                    character.CurrentDetermination++;
                    DamageCharacterBy(1, character);
                }
            }
        }
        public static void RaiseCharacterDeterminationBy(int amount, Character character)
        {
            if (amount < 0) amount = 0;
            if (character is ISideCharacter) return;
            character.CurrentDetermination += amount;
        }
        public static bool IsCharacterHealthInPreMoralChangeRange(Character character)
        {
            foreach (int value in character.MoraleChangeArray)
            {
                if (value == character.CurrentHealth)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
