using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Overlay.MainMenu
{
    public static class TempoarySettings
    {
        public static void Reset()
        {
            NumberOfPlayers = 0;
            NumberOfSelectedCharacters = 0;
            Party = new Party();
        }
        public static int NumberOfPlayers { get; set; }
        public static int NumberOfSelectedCharacters { get; set; }
        public static Party Party;

        public static void AddCharacterToParty(PartySelector partySelector)
        {
            if (partySelector == PartySelector.cook) { Party.cook = new Cook(); NumberOfSelectedCharacters++; }
            else if (partySelector == PartySelector.soldier) { Party.soldier = new Soldier(); NumberOfSelectedCharacters++; }
            else if (partySelector == PartySelector.explorer) { Party.explorer = new Explorer(); NumberOfSelectedCharacters++; }
            else if (partySelector == PartySelector.carpenter) { Party.carpenter = new Carpenter(); NumberOfSelectedCharacters++; }
            }

        public static void RemoveCharacterFromParty(PartySelector partySelector)
        {
            if (partySelector == PartySelector.cook) { Party.cook = null; NumberOfSelectedCharacters--; }
            else if (partySelector == PartySelector.soldier) { Party.soldier = null; NumberOfSelectedCharacters--; }
            else if (partySelector == PartySelector.explorer) { Party.explorer = null; NumberOfSelectedCharacters--; }
            else if (partySelector == PartySelector.carpenter) { Party.carpenter = null; NumberOfSelectedCharacters--; }
            }

    }

    public struct Party
    {
        public Cook cook;
        public Soldier soldier;
        public Explorer explorer;
        public Carpenter carpenter;
    }

    public enum PartySelector
    {
        cook,
        soldier,
        explorer,
        carpenter,
    }
}
