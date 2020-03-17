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
        public static Character[] PartySession;
        public static void CreateParty(Party newParty, int partySize)
        {
            if (partySize == 1) CreateOnePlayerParty(newParty);
            if (partySize == 2) CreateTwoPlayerParty(newParty);
            if (partySize == 3) CreateThreePlayerParty(newParty);
            if (partySize == 4) CreateFourPlayerParty(newParty);
        }

        private static void CreateFourPlayerParty(Party newParty)
        {
            throw new NotImplementedException();
        }

        private static void CreateThreePlayerParty(Party newParty)
        {
            throw new NotImplementedException();
        }

        private static void CreateTwoPlayerParty(Party newParty)
        {
            throw new NotImplementedException();
        }

        private static void CreateOnePlayerParty(Party newParty)
        {
            PartySession = new Character[3];
            if (newParty.cook != null) PartySession[0] = newParty.cook;
            else if (newParty.carpenter != null) PartySession[0] = newParty.carpenter;
            else if (newParty.explorer != null) PartySession[0] = newParty.explorer;
            else if (newParty.soldier != null) PartySession[0] = newParty.soldier;

            //Create SideCharacters
            PartySession[1] = new Friday();
            PartySession[2] = new Dog();

            //Set character as active
            PartySession[0].IsActiveCharacter = true;
        }
    }
}
