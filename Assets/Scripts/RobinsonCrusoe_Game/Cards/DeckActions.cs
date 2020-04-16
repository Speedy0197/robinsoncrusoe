using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards
{
    public static class DeckActions
    {
        public static void Shuffle<T>(List<T> Deck)
        {
            System.Random random = new System.Random();
            int n = Deck.Count;
            while(n > 1)
            {
                int k = random.Next(n - 1);
                n--;
                T temp = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = temp;
            }
        }
    }
}
