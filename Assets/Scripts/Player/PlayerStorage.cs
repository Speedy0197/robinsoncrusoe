using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public static class PlayerStorage
    {
        private static Player[] allPlayers = new Player[4] { null, null, null, null };
        private static int activePlayer = 0;

        public static void AddPlayer(Player player)
        {
            for(int i = 0; i < allPlayers.Length; i++)
            {
                if(allPlayers[i] == null)
                {
                    allPlayers[i] = player;
                    return;
                }
            }
            throw new Exception("Maximum amount of players reached");
        }

        public static void SetNextPlayerAsActive()
        {
            activePlayer++;
            if (activePlayer == allPlayers.Length)
                activePlayer = 0;
        }

        public static Player GetActivePlayer()
        {
            return allPlayers[activePlayer];
        }

        public static int GetAmountOfPlayers()
        {
            int players = 0;
            foreach(Player p in allPlayers)
            {
                if (p != null) players++;
            }
            return players;
        }
    }
}
