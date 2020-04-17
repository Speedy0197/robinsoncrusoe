using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionInit : MonoBehaviour
{
    public ActionContainer myAction;
    public int maxNumberOfTokens = 2;

    public GameObject[] selectors;
    public Button saveChangesBtn;

    // Start is called before the first frame update
    void Start()
    {
        saveChangesBtn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        foreach(var selector in selectors)
        {
            var selectorClass = selector.GetComponent<ActionToken_Selector>();
            myAction.SetValue(selectorClass.character, selectorClass.SpendTokens);
        }
    }

    public void SetAktion(ActionContainer actionContainer)
    {
        myAction = actionContainer;
    }
}
