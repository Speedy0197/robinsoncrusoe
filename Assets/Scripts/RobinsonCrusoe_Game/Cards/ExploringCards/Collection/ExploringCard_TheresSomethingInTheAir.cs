using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_TheresSomethingInTheAir : ICard, IExploringCard
    {
        private int eventNumber = 0;
        public void ExecuteEvent()
        {
            if (eventNumber == 0)
            {
                ExecuteActiveThreat();
                eventNumber++;
            }
            else
            {
                ExecuteFutureThreat();
            }
        }

        private void ExecuteFutureThreat()
        {
            ExploringCard_Deck.GlobalSetQuestionMarkOnDeck();
        }

        private void ExecuteActiveThreat()
        {
            ExploringCard_Deck.GlobalSetQuestionMarkOnDeck();
        }

        public string GetCardDescription()
        {
            return "Ein grünes Fragezeichen wird zusätzlich platziert.";
        }

        public int GetMaterialNumber()
        {
            return 19;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "There's something in the Air";
        }
    }
}
