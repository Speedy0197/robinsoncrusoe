using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupCollect : MonoBehaviour, IPointerClickHandler
{
    public static event EventHandler ButtonClicked;

    public GameObject button1;
    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonClicked?.Invoke(this, new EventArgs());
    }
}
