using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventDangerAction_Processing : MonoBehaviour
{
    private ThreatCardHolder card;
    private ThreatCardViewer viewer;
    public void ProcessPreventAction(ActionContainer action)
    {
        card = action.ReferingObject as ThreatCardHolder;
        viewer = FindObjectOfType<ThreatCardViewer>();

        var eventCard = card.ThreatCard.CardClass as IEventCard;
        eventCard.ExecuteSuccessEvent();

        viewer.RemoveCard(card.ThreatLevel);
    }
}
