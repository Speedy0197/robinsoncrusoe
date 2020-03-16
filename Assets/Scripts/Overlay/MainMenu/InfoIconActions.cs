using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoIconActions : MonoBehaviour, IPointerClickHandler
{
    public string abilityName;
    public string abilityCost;
    public string abilityInfo;

    public GameObject popUpPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        var canvas = FindObjectOfType<Canvas>();
        Instantiate(popUpPrefab, canvas.transform);

        var popUp = FindObjectOfType<AbilityInfoLoader>();
        popUp.SetAbilityName(abilityName);
        popUp.SetAbilityCost(abilityCost);
        popUp.SetAbilityDescription(abilityInfo);
    }

}
