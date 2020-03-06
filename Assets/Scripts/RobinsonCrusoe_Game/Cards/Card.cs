using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards
{
    public interface IEventCard
    {   

        bool IsCardTypeBook();
        string GetQuestionMarkColour();
        string ExecuteActiveThreat();
        string ExecuteFutureThreat();
        void RemoveCard();
        //void SpawnCard(GameObject cardObject, Transform placeToSpawn);
                   
    }
}
