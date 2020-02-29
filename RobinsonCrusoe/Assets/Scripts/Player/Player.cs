using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public class Player
    {
        private Character gameCharacter;
        private int playerNumber;

        public Player()
        {
            playerNumber = 1;
            gameCharacter = new Cook();

            RobinsonCrusoe_Game.GameAttributes.Moral.AddToMoralSystem(this);
        }

        public Character GetCharacter()
        {
            return gameCharacter;
        }
    }

    public static class PlayerHelper
    {
        private static Player instance = null;

        public static Player Instance()
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }
    }
}
