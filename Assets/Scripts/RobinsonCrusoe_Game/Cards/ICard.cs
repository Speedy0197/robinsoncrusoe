using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards
{
    public interface ICard
    {
        int GetMaterialNumber();
        void ExecuteEvent();
        string GetCardDescription();
        bool HasDiscardOption();
    }

    public class RessourceCosts
    {
        public RessourceCosts(int wood, int leather, int food)
        {
            AmountOfWood = wood;
            AmountOfLeather = leather;
            AmountOfFood = food;
        }

        public int AmountOfWood { get; private set; }
        public int AmountOfLeather { get; private set; }
        public int AmountOfFood { get; private set; }
    }
}
