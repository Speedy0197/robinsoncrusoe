using Assets.Scripts.RobinsonCrusoe_Game.Characters;
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
    }
}
