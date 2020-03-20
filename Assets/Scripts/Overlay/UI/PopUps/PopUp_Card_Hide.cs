using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp_Card_Hide : MonoBehaviour, IPointerClickHandler
{
    GameObject currentPopUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        currentPopUp.SetActive(false);
        
        //TODO put PopUp into Reactivation Button
    }
}
