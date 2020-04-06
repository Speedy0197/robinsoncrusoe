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
        bool IsCardTypeBook();
        QuestionMark GetQuestionMark();
        void ExecuteSuccessEvent();
        bool CanCompleteQuest();
        int GetActionCosts();
        RessourceCosts GetRessourceCosts();
    }
}

public enum QuestionMark
{
    None,
    Gathering,
    Building,
    Exploring
}
