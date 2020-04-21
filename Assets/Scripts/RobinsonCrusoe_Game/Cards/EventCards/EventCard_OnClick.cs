using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
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
}
