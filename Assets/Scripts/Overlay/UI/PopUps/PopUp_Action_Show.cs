using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Action_Show : MonoBehaviour
{
    public Text actionOverview;
    public Button confirm;
    public GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);
        actionOverview.text = CheckAllActions();
    }

    private void TaskOnClick()
    {
        if (AllActionsUsed())
        {
            Destroy(popUp);
            var phaseView = FindObjectOfType<PhaseView>();
            phaseView.NextPhase();
        }
    }

    private bool AllActionsUsed()
    {
        var party = PartyHandler.PartySession;
        foreach(var character in party)
        {
            if (character.CurrentNumberOfActions != 0) return false;
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: update text???
    }

    private string CheckAllActions()
    {
        string actionString = string.Empty;
        var actions = FindObjectsOfType<Action_Template>();
        foreach(var action in actions)
        {
            //TODO: get info from pos
            //Build string
        }
        return actionString;
    }
}
