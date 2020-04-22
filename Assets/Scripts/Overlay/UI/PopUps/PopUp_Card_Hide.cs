using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;

public class PopUp_Card_Hide : MonoBehaviour, IPointerClickHandler
{
    public GameObject currentPopUp;
    private PopUp_Reactivate reactivator;

    private void Start()
    {
        reactivator = FindObjectOfType<PopUp_Reactivate>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hide();
    }

    public void Hide()
    {
        Analytics.CustomEvent("Minimized PopUp");
        currentPopUp.SetActive(false);

        reactivator.SetSaved(currentPopUp);
    }
}
