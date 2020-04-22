using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public static class PartyActions
    { 
        public static Character GetActiveCharacter()
        {
            foreach(Character c in PartyHandler.PartySession)
            {
                if (c is ISideCharacter) continue;
                if (c.IsActiveCharacter) return c;
            }
            return null;
        }

        public static void LowerDeterminationOfPartyBy(int amount)
        {
            foreach (Character c in PartyHandler.PartySession)
            {
                CharacterActions.LowerCharacterDeterminationBy(amount, c);
            }
        }

        public static void DamageAllPlayers(int amount)
        {
            foreach (Character c in PartyHandler.PartySession)
            {
                if (c is ISideCharacter) continue;
                CharacterActions.DamageCharacterBy(1, c);
            }
        }

        public static int GetNumberOfPlayers()
        {
            int result = 0;
            foreach(var character in PartyHandler.PartySession)
            {
                if (character is ISideCharacter) continue;
                result++;
            }
            return result;
        }

        public static void SetNextActiveCharacter()
        {
            bool foundCurrentCharacter = false;
            for(int i = 0; i < PartyHandler.PartySession.Length; i++)
            {
                if (PartyHandler.PartySession[i] is ISideCharacter)
                {
                    if (i == PartyHandler.PartySession.Length - 1) i = -1;
                    continue;
                }


                if (PartyHandler.PartySession[i].IsActiveCharacter)
                {
                    PartyHandler.PartySession[i].IsActiveCharacter = false;
                    foundCurrentCharacter = true;

                    if (i == PartyHandler.PartySession.Length - 1) i = -1;
                    continue;
                }

                if (foundCurrentCharacter)
                {
                    PartyHandler.PartySession[i].IsActiveCharacter = true;
                    return;
                }
            }
        }

        public static void TokenReset()
        {
            foreach (var character in PartyHandler.PartySession)
            {
                character.CurrentNumberOfActions = character.MaxNumberOfActions;
            }
        }

        public static void Sleep()
        {
            foreach (Character c in PartyHandler.PartySession)
            {
                if (c is ISideCharacter) continue;

                if(PerishableFood.currentAmountOfPerishableFood > 0)
                {
                    PerishableFood.DecreaseBy(1);
                }
                else if(UnperishableFood.currentAmountOfUnperishableFood > 0)
                {
                    UnperishableFood.DecreaseBy(1);
                }
                else
                {
                    CharacterActions.DamageCharacterBy(2, c);
                }
            }
        }
    }
}
