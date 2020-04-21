using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenMission : MonoBehaviour, IPointerClickHandler
{
    public GameObject popup_Mission;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            var ui = FindObjectOfType<GetUIBase>();
            Instantiate(popup_Mission, ui.transform);
        }
    }
}
