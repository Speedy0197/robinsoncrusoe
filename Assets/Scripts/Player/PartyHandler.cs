using Assets.Scripts.Overlay.MainMenu;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public static class PartyHandler
    {
        public static int PartySize;

        public static Character[] PartySession;
        public static void CreateParty(Party newParty, int partySize)
        {
            PartySize = partySize;

            if (partySize == 1) CreateOnePlayerParty(newParty);
            if (partySize == 2) CreateTwoPlayerParty(newParty);
            if (partySize == 3) CreateThreePlayerParty(newParty);
            if (partySize == 4) CreateFourPlayerParty(newParty);
        }

        private static void CreateFourPlayerParty(Party newParty)
        {
            int index = 0;
            PartySession = new Character[4];
            if (newParty.cook != null) { PartySession[index] = newParty.cook; index++; }
            if (newParty.carpenter != null) { PartySession[index] = newParty.carpenter; index++; }
            if (newParty.explorer != null) { PartySession[index] = newParty.explorer; index++; }
            if (newParty.soldier != null) { PartySession[index] = newParty.soldier; index++; }

            //TODO: Additional changes for four players

            //Set character as active
            PartySession[0].IsActiveCharacter = true;
        }

        private static void CreateThreePlayerParty(Party newParty)
        {
            int index = 0;
            PartySession = new Character[3];
            if (newParty.cook != null) { PartySession[index] = newParty.cook; index++; }
            if (newParty.carpenter != null) { PartySession[index] = newParty.carpenter; index++; }
            if (newParty.explorer != null) { PartySession[index] = newParty.explorer; index++; }
            if (newParty.soldier != null) { PartySession[index] = newParty.soldier; index++; }

            //Set character as active
            PartySession[0].IsActiveCharacter = true;
        }

        private static void CreateTwoPlayerParty(Party newParty)
        {
            int index = 0;
            PartySession = new Character[3];
            if (newParty.cook != null) { PartySession[index] = newParty.cook; index++; }
            if (newParty.carpenter != null) { PartySession[index] = newParty.carpenter; index++; }
            if (newParty.explorer != null) { PartySession[index] = newParty.explorer; index++; }
            if (newParty.soldier != null) { PartySession[index] = newParty.soldier; index++; }

            //Create SideCharacters
            PartySession[index] = new Friday();

            //Set character as active
            PartySession[0].IsActiveCharacter = true;
        }

        private static void CreateOnePlayerParty(Party newParty)
        {
            int index = 0;
            PartySession = new Character[3];
            if (newParty.cook != null) { PartySession[index] = newParty.cook; index++; }
            if (newParty.carpenter != null) { PartySession[index] = newParty.carpenter; index++; }
            if (newParty.explorer != null) { PartySession[index] = newParty.explorer; index++; }
            if (newParty.soldier != null) { PartySession[index] = newParty.soldier; index++; }

            //Create SideCharacters
            PartySession[index] = new Friday();
            index++;
            PartySession[index] = new Dog();

            //Set character as active
            PartySession[0].IsActiveCharacter = true;
        }
    }
}
