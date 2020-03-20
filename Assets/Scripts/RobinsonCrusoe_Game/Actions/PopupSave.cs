using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSave : MonoBehaviour
{
    public static event EventHandler SaveButtonClicked;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        SaveButtonClicked?.Invoke(this, new EventArgs());
    }
}
