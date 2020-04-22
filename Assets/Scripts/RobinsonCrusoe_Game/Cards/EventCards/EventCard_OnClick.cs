using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventCard_OnClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            var threat = GetComponent<ThreatCardHolder>();
            if(threat.ThreatCard.CardClass != null && threat.ThreatCard.CardClass is IEventCard)
            {
                var card = threat.ThreatCard.CardClass as IEventCard;

                if (card.CanCompleteQuest())
                {
                    GetComponent<Action_PreventDanger>().ExecuteTask();
                }
            }
        }
    }

    private bool CheckBuildCosts(IEventCard card)
    {
        var costs = card.GetRessourceCosts();

        bool retVal = true;
        if (Wood.currentAmountOfWood < costs.AmountOfWood) retVal = false;
        if (Fur.currentAmountOfFur < costs.AmountOfLeather) retVal = false;
        if (FoodStorage.GetTotal() < costs.AmountOfFood) retVal = false;
        return retVal;
    }
}
