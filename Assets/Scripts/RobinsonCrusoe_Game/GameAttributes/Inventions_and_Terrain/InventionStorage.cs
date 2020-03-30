using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain
{
    public static class InventionStorage
    {
        private static Dictionary<Invention, bool> AvailableInventions;

        public static void CreateStorageSpace()
        {
            AvailableInventions = new Dictionary<Invention, bool>();

            //Add all possible inventions to dictionary
            AvailableInventions.Add(Invention.Basket, false);
            AvailableInventions.Add(Invention.Bed, false);
            AvailableInventions.Add(Invention.Belt, false);
            AvailableInventions.Add(Invention.Bow, false);
            AvailableInventions.Add(Invention.Cellar, false);
            AvailableInventions.Add(Invention.Corral, false);
            AvailableInventions.Add(Invention.Diary, false);
            AvailableInventions.Add(Invention.Drums, false);
            AvailableInventions.Add(Invention.Fireplace, false);
            AvailableInventions.Add(Invention.Furnance, false);
            AvailableInventions.Add(Invention.Lantern, false);
            AvailableInventions.Add(Invention.Moat, false);
            AvailableInventions.Add(Invention.Pit, false);
            AvailableInventions.Add(Invention.Raft, false);
            AvailableInventions.Add(Invention.Sack, false);
            AvailableInventions.Add(Invention.Shield, false);
            AvailableInventions.Add(Invention.Shortcut, false);
            AvailableInventions.Add(Invention.Sling, false);
            AvailableInventions.Add(Invention.Snare, false);
            AvailableInventions.Add(Invention.Spear, false);
            AvailableInventions.Add(Invention.Wall, false);
        }

        public static void UnlockInvention(Invention invention)
        {
            AvailableInventions[invention] = true;
        }
        public  static void LockInvention(Invention invention)
        {
            AvailableInventions[invention] = false;
        }
    }

    public enum Invention
    {
        Basket,
        Bed,
        Belt,
        Bow,
        Cellar,
        Corral,
        Diary,
        Drums,
        Fireplace,
        Furnance,
        Lantern,
        Moat,
        Pit,
        Raft,
        Sack,
        Shield,
        Shortcut,
        Sling,
        Snare,
        Spear,
        Wall
    }
}
