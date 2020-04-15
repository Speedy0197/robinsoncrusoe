using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp_Reactivate : MonoBehaviour
{
    public GameObject reactivatorImage;

    private Stack<GameObject> savedObjects;

    public static event EventHandler ReactivatorImageClicked;
    private void Start()
    {
        savedObjects = new Stack<GameObject>();
        ReactivatorImageClicked += OnImageClicked;
    }

    private void OnImageClicked(object sender, EventArgs e)
    {
        OpenSaved();
    }

    public void SetSaved(GameObject popUp)
    {
        savedObjects.Push(popUp);

        reactivatorImage.SetActive(true);
    }

    public void OpenSaved()
    {
        var savedPopUp = savedObjects.Pop();
        savedPopUp.SetActive(true);

        reactivatorImage.SetActive(false);
    }

    public static void HandleImageClick()
    {
        ReactivatorImageClicked?.Invoke(null, new EventArgs());
    }
}
