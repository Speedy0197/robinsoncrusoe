using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain
{
    public static class TerrainStorage
    {
        private static Dictionary<TerrainType, StorageBox> AvailableTerrain;
        public static void CreateStorageSpace()
        {
            AvailableTerrain = new Dictionary<TerrainType, StorageBox>();
            AvailableTerrain.Add(TerrainType.Beach, new StorageBox(true, 1)); //Set this as start value, for the starting tile

            //Add all the other terrains, at start all types are locked
            AvailableTerrain.Add(TerrainType.Hill, new StorageBox());
            AvailableTerrain.Add(TerrainType.Mountain, new StorageBox());
            AvailableTerrain.Add(TerrainType.Plain, new StorageBox());
            AvailableTerrain.Add(TerrainType.River, new StorageBox());
            AvailableTerrain.Add(TerrainType.Volcano, new StorageBox());
        }

        public static void UnlockTerrain(TerrainType terrain)
        {
            var box = AvailableTerrain[terrain];
            box.IsUnlocked = true;
            box.TimesUnlocked += 1;
        }

        public static void LockTerrain(TerrainType terrain)
        {
            var box = AvailableTerrain[terrain];
            box.TimesUnlocked -= 1;
            if(box.TimesUnlocked <= 0)
            {
                box.IsUnlocked = false;
                box.TimesUnlocked = 0;
            }
        }
    }

    class StorageBox
    {
        public bool IsUnlocked { get; set; }
        public int TimesUnlocked { get; set; }
        public StorageBox()
        {
            IsUnlocked = false;
            TimesUnlocked = 0;
        }
        public StorageBox(bool isUnlocked, int numbetOfTimes)
        {
            IsUnlocked = isUnlocked;
            TimesUnlocked = numbetOfTimes;
        }
    }
}
