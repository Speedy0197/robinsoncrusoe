using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards
{
    public interface IEventCard
    {
        Material GetMaterial();
        bool IsCardTypeBook();
        QuestionMark GetQuestionMark();
        void ExecuteActiveThreat();
        void ExecuteFutureThreat();
        void ExecuteCompletionEvent();
        void RemoveCard();
        //void SpawnCard(GameObject cardObject, Transform placeToSpawn);
                   
    }
}

public enum QuestionMark
{
    None,
    Gathering,
    Building,
    Exploring
}
