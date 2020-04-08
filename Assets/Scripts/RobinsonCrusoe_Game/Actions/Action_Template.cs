using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Action_Template : MonoBehaviour
{
    private GameObject popup;
    private GameObject popup_position;
    public ActionType actionType;
    public static event EventHandler ContinueButtonIsClickable;
    public static event EventHandler ContinueButtonIsNotClickable;
    public static event EventHandler ActionIsClickable;
    public static event EventHandler ActionIsNotClickable;

    public Position pos = null;

    private GameObject InstantiatedPopup;

    private bool isClickable = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Position();


        if (actionType == ActionType.build) popup = Resources.Load("prefabs/PopUp_Action") as GameObject;
        if (actionType == ActionType.collect) popup = Resources.Load("prefabs/PopUp_Collect") as GameObject;
        if (actionType == ActionType.explore) popup = Resources.Load("prefabs/PopUp_Action") as GameObject;

        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
        ActionIsClickable += SetActionIsClickable;
        ActionIsNotClickable += SetActionIsNotClickable;
        ContinueButton.ActionIsNotClickable += SetActionIsNotClickable;
    }

    void OnMouseDown()
    {
        if (isClickable)
        {
            ActionIsNotClickable?.Invoke(this, new EventArgs());
            popup_position = GameObject.Find("UI_Base");
            InstantiatedPopup = Instantiate(popup, popup_position.transform);
            InstantiatedPopup.GetComponent<PopupAction>().SetText(0, actionType.ToString().ToUpper());
            PopupSave.SaveButtonClicked += Save;
            PopupCancel.CancelButtonClicked += Cancel;
            Dictionary<string, float> dictionary = pos.GetDictionary();

            int i = 1;
            foreach (var character in PartyHandler.PartySession)
            {
                if (character != null) InstantiatedPopup.GetComponent<PopupAction>().SetText(i, character.CharacterName);
                InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, dictionary[character.CharacterName]);
                i++;
            }

        }
    }

    private void Save(object sender, System.EventArgs e)
    {
        ActionIsClickable?.Invoke(this, new EventArgs());
        PopupAction popup = InstantiatedPopup.GetComponent<PopupAction>();
        float Slider1Value = popup.GetSliderValue(1);
        float Slider2Value = popup.GetSliderValue(2);
        float Slider3Value = popup.GetSliderValue(3);
        float StartSlider1Value = popup.GetStartSliderValue(1);
        float StartSlider2Value = popup.GetStartSliderValue(2);
        float StartSlider3Value = popup.GetStartSliderValue(3);


        if (StartSlider1Value != Slider1Value)
        {
            CheckSliderValueAndChangeStuff(0, StartSlider1Value, Slider1Value);
        }
        if (StartSlider2Value != Slider2Value)
        {
            CheckSliderValueAndChangeStuff(1, StartSlider2Value, Slider2Value);
        }
        if (StartSlider3Value != Slider3Value)
        {
            CheckSliderValueAndChangeStuff(2, StartSlider3Value, Slider3Value);
        }

        bool Done = true;

        foreach (var marker in MarkerHandler2.dictionary)
        {
            if (marker.Value.actionType == ActionType.unknown)
            {
                Done = false;
                break;
            }
        }

        if (Done)
        {
            ContinueButtonIsClickable?.Invoke(this, new EventArgs());
        }
        else
        {
            ContinueButtonIsNotClickable?.Invoke(this, new EventArgs());
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

    private void SetActionIsClickable(object sender, System.EventArgs e)
    {
        isClickable = true;
    }

    private void SetActionIsNotClickable(object sender, System.EventArgs e)
    {
        isClickable = false;
    }

    private void Cancel(object sender, System.EventArgs e)
    {
        PopupSave.SaveButtonClicked -= Save;
        PopupCancel.CancelButtonClicked -= Cancel;
        ActionIsClickable?.Invoke(this, new EventArgs());
        Destroy(InstantiatedPopup);
    }

    private void CheckSliderValueAndChangeStuff(int characterNr, float StartSliderValue, float SliderValue)
    {
        string characterName = PartyHandler.PartySession[characterNr].CharacterName;
        pos.SetDictionary(characterName, SliderValue);
        PartyHandler.PartySession[characterNr].CurrentNumberOfActions += (int)(StartSliderValue - SliderValue);

        if (StartSliderValue < SliderValue)
        {
            if (SliderValue - StartSliderValue == 1)
            {
                MarkerHandler2.SetMarkerByName(characterName, this.transform.position, actionType, 1);
            }
            else if (SliderValue - StartSliderValue == 2)
            {
                MarkerHandler2.SetMarkerByName(characterName, this.transform.position, actionType, 1);
                MarkerHandler2.SetMarkerByName(characterName, this.transform.position, actionType, 1);
            }
        }
        else if (StartSliderValue > SliderValue)
        {
            if (StartSliderValue - SliderValue == 1)
            {
                MarkerHandler2.RemoveMarkerByName(characterName, this.transform.position, actionType);
            }
            else if (StartSliderValue - SliderValue == 2)
            {
                MarkerHandler2.RemoveMarkerByName(characterName, this.transform.position, actionType);
                MarkerHandler2.RemoveMarkerByName(characterName, this.transform.position, actionType);
            }

        }
    }
}


