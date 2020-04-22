using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCancel : MonoBehaviour
{
    public event EventHandler CancelButtonClicked;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        CancelButtonClicked?.Invoke(this, new EventArgs());
    }
}
