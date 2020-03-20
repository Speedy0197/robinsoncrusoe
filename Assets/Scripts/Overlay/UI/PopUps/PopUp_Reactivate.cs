using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp_Reactivate : MonoBehaviour, IPointerClickHandler
{
    public GameObject savedPopUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        savedPopUp.SetActive(true);
    }

    public void SetSaved(GameObject popUp)
    {
        savedPopUp = popUp;
    }
}
