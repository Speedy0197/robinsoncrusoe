using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.RobinsonCrusoe_Game.Characters
{
    public static class CharacterActions
    {
        public static void DamageCharacterBy(int amount, Character character)
        {
            if (amount < 0) amount = 0;
            while (amount > 0)
            {
                if(character.CurrentHealth > 0) character.CurrentHealth -= 1;
                if (character.CurrentHealth <= 0)
                {
                    character.CurrentDetermination = 0;
                    //Character Death
                    if (character is ISideCharacter)
                    {
                        character.IsDead = true;
                        character.CurrentHealth = 0;
                    }
                    else
                    {
                        EndGame_Object.TriggerDefeat("OH NEIN!\r\n" + character.CharacterName + " hat seinen letzten Atemzug getan!\r\n" +
                            "Ohne seine Unterstützung wird der Rest der Gruppe auch nicht mehr lange überleben!");
                    }
                }
                if (!(character is ISideCharacter)
                    && CheckForMoralLoss(character))
                {
                    Moral.LowerMoral();
                }
                amount--;
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
                //DamageCharacterBy(amount, character);
            }
            else
            {
                character.CurrentDetermination -= amount;

                while (character.CurrentDetermination < 0)
                {
                    character.CurrentDetermination++;
                    DamageCharacterBy(1, character);
                    Debug.Log(character.CurrentDetermination);
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
