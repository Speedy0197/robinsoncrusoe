using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp_Card_Hide : MonoBehaviour, IPointerClickHandler
{
    public GameObject currentPopUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        currentPopUp.SetActive(false);

        var reactivator = FindObjectOfType<PopUp_Reactivate>();
        reactivator.SetSaved(currentPopUp);
    }
}
