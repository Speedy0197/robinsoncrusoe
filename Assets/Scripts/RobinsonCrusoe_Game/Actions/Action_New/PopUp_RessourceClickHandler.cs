using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp_RessourceClickHandler : MonoBehaviour, IPointerClickHandler
{
    public RessourceType RessourceType { get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = FindObjectOfType<PopUp_RessourceSelection>();
        obj.RaiseEvent(RessourceType);
    }
}
