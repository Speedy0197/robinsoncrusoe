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
        private static int _partySize;
        private static Character[] characters;
        private static int mainCharacter;

        //private static SideCharacter[] sideCharacters;
        //private static bool hasSideCharacters;

        private const int minAmountOfPlayers = 1;
        private const int maxAmountOfPlayers = 4;

        public static void BuildNewParty(int partySize)
        {
            if (partySize < minAmountOfPlayers) partySize = minAmountOfPlayers;
            if (partySize > maxAmountOfPlayers) partySize = maxAmountOfPlayers;
            _partySize = partySize;

            characters = new Character[_partySize];
            InitArrayWithNull();
            mainCharacter = 0;

            /* if(_partySize == 1) Create Friday and Dog
             * if(_partySize == 2) Create Friday
             */
        }

        private static void InitArrayWithNull()
        {
            for(int i = 0; i < characters.Length; i++)
            {
                characters[i] = null;
            }
        }

        public static bool AddCharacterToParty(Character character)
        {
            for(int i = 0; i < characters.Length; i++)
            {
                if(characters[i] == null)
                {
                    characters[i] = character;
                    return true;
                }
            }
            return false;
        }

        public static Character GetMainCharacter()
        {
            while(characters[mainCharacter] == null)
            {
                ChangeMainCharacterToNextPlayer();
            }
            return characters[mainCharacter];
        }

        public static void ChangeMainCharacterToNextPlayer()
        {
            mainCharacter++;
            if(mainCharacter >= characters.Length)
            {
                mainCharacter = 0;
            }
        }

        public static void DealDmgToWholeParty(int amount)
        {
            foreach(Character c in characters)
            {
                if (c == null) continue;
                c.TakePointsOfDamage(amount, DamageType.Damage);
            }
        }

        public static void WholePartyMoralTokenChange(int amount)
        {
            foreach (Character c in characters)
            {
                if (c == null) continue;
                c.ChangeMoralTokenValueBy(amount);
            }
        }
    }
}
