using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseAbilityInfo : MonoBehaviour, IPointerClickHandler
{
    public GameObject abilityInfoScreen;

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(abilityInfoScreen);
    }
}
