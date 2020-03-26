﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp_Reactivate : MonoBehaviour
{
    public GameObject savedPopUp;
    public GameObject reactivatorImage;

    public static event EventHandler ReactivatorImageClicked;
    private void Start()
    {
        ReactivatorImageClicked += OnImageClicked;
    }

    private void OnImageClicked(object sender, EventArgs e)
    {
        OpenSaved();
    }

    public void SetSaved(GameObject popUp)
    {
        savedPopUp = popUp;

        reactivatorImage.SetActive(true);
    }

    public void OpenSaved()
    {
        savedPopUp.SetActive(true);

        reactivatorImage.SetActive(false);
    }

    public static void HandleImageClick()
    {
        ReactivatorImageClicked?.Invoke(null, new EventArgs());
    }
}