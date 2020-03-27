﻿using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_Template : MonoBehaviour
{
    public GameObject popup;
    public GameObject popup_position;

    public Position pos = null;

    private GameObject InstantiatedPopup;

    private bool isClickable = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Position();
        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
    }

    void OnMouseDown()
    {
        if (isClickable)
        {
            InstantiatedPopup = Instantiate(popup, popup_position.transform);
            PopupSave.SaveButtonClicked += Save;
            PopupCancel.CancelButtonClicked += Cancel;
            Dictionary<string, float> dictionary = pos.GetDictionary();

            int i = 1;
            foreach (var character in PartyHandler.PartySession)
            {
                InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, dictionary[character.CharacterName]);
                i++;
            }

        }
    }

    private void Save(object sender, System.EventArgs e)
    {
        PopupAction popup = InstantiatedPopup.GetComponent<PopupAction>();
        float Slider1Value = popup.GetSliderValue(1);
        float Slider2Value = popup.GetSliderValue(2);
        float Slider3Value = popup.GetSliderValue(3);

        if (popup.GetStartSliderValue(1) != Slider1Value)
        {
            string characterName = PartyHandler.PartySession[0].CharacterName;
            pos.SetDictionary(characterName, Slider1Value);
            PartyHandler.PartySession[0].CurrentNumberOfActions += (int)(popup.GetStartSliderValue(1) - Slider1Value);
            GameObject.Find("PlayerMarker1").transform.position = this.transform.position + new Vector3(0, 4, 0);
            GameObject.Find("DogMarker").transform.position = this.transform.position + new Vector3(0, 12, 0);
        }

        if (popup.GetStartSliderValue(2) != Slider2Value)
        {
            pos.SetDictionary(PartyHandler.PartySession[1].CharacterName, Slider2Value);
            PartyHandler.PartySession[1].CurrentNumberOfActions += (int)(popup.GetStartSliderValue(2) - Slider2Value);
        }

        if (popup.GetStartSliderValue(3) != Slider3Value)
        {
            pos.SetDictionary(PartyHandler.PartySession[2].CharacterName, Slider3Value);
            PartyHandler.PartySession[2].CurrentNumberOfActions += (int)(popup.GetStartSliderValue(3) - Slider3Value);
        }




        PopupSave.SaveButtonClicked -= Save;
        PopupCancel.CancelButtonClicked -= Cancel;
        Destroy(InstantiatedPopup);
    }

    private void ActionPhaseTriggered(object sender, System.EventArgs e)
    {
        PhaseView view = (PhaseView)sender;

        if (view.GetCurrentPhase() != E_Phase.Action)
        {
            return;
        }
        else
        {
            isClickable = true;
        }

    }

    private void Cancel(object sender, System.EventArgs e)
    {
        PopupSave.SaveButtonClicked -= Save;
        PopupCancel.CancelButtonClicked -= Cancel;
        Destroy(InstantiatedPopup);
    }
}

    
