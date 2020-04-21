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


        if (actionType == ActionType.build) popup = Resources.Load("prefabs/PopUp_Build") as GameObject;
        if (actionType == ActionType.collect) popup = Resources.Load("prefabs/PopUp_Collect") as GameObject;
        if (actionType == ActionType.explore) popup = Resources.Load("prefabs/PopUp_Explore") as GameObject;

        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
        ActionIsClickable += SetActionIsClickable;
        ActionIsNotClickable += SetActionIsNotClickable;
        //ContinueButton.ActionIsNotClickable += SetActionIsNotClickable;
    }

    //void OnMouseDown()
    //{
    //    if (isClickable)
    //    {
    //        ActionIsNotClickable?.Invoke(this, new EventArgs());
    //        popup_position = GameObject.Find("UI_Base");
    //        InstantiatedPopup = Instantiate(popup, popup_position.transform);
    //        if (actionType == ActionType.build)
    //        {
    //            InstantiatedPopup.GetComponent<PopupAction>().SetText(0, actionType.ToString().ToUpper());
    //            InstantiatedPopup.GetComponent<PopupAction>().SetMaterial(this.gameObject.GetComponent<MeshRenderer>());
    //            PopupSave.SaveButtonClicked += Save;
    //            PopupCancel.CancelButtonClicked += Cancel;
    //            Dictionary<string, float> dictionary = pos.GetDictionary();

    //            int i = 1;

    //            foreach (var character in PartyHandler.PartySession)
    //            {
    //                if (character != null) InstantiatedPopup.GetComponent<PopupAction>().SetText(i, character.CharacterName);
    //                InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, dictionary[character.CharacterName]);
    //                i++;
    //            }

    //        }
    //        if (actionType == ActionType.collect)
    //        {
    //            PopupCollect.ButtonClicked += Collect;
    //        }
    //        if (actionType == ActionType.explore)
    //        {
    //            InstantiatedPopup.GetComponent<PopupAction>().SetText(0, actionType.ToString().ToUpper());

    //            PopupSave.SaveButtonClicked += Save;
    //            PopupCancel.CancelButtonClicked += Cancel;

    //            Dictionary<string, float> dictionary = pos.GetDictionary();
    //            int i = 1;
    //            foreach (var character in PartyHandler.PartySession)
    //            {
    //                if (character != null) InstantiatedPopup.GetComponent<PopupAction>().SetText(i, character.CharacterName);
    //                InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, dictionary[character.CharacterName]);
    //                i++;
    //            }

    //        }

    //    }
    //}

    //private void Collect(object sender, EventArgs e)
    //{
    //    PopupCollect collect = (PopupCollect)sender;
    //    PopupCollect.ButtonClicked -= Collect;
    //    Destroy(InstantiatedPopup);

    //    GameObject popup2 = Resources.Load("prefabs/PopUp_Action") as GameObject;
    //    InstantiatedPopup = Instantiate(popup2, popup_position.transform);
    //    InstantiatedPopup.GetComponent<PopupAction>().SetText(0, actionType.ToString().ToUpper());
    //    InstantiatedPopup.GetComponent<PopupAction>().SetImage(collect.button1.GetComponent<RawImage>());

    //    PopupSave.SaveButtonClicked += Save;
    //    PopupCancel.CancelButtonClicked += Cancel;

    //    Dictionary<string, dynamic> dictionary = pos.GetCollectData();
    //    int i = 1;

    //    foreach (var character in PartyHandler.PartySession)
    //    {
    //        if (character != null) InstantiatedPopup.GetComponent<PopupAction>().SetText(i, character.CharacterName);

    //        if (dictionary[character.CharacterName].wood == 1 && collect.button1.name == "Wood") InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, 1);
    //        if (dictionary[character.CharacterName].wood == 2 && collect.button1.name == "Wood") InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, 2);
            
    //        if (dictionary[character.CharacterName].food == 1 && collect.button1.name == "Food") InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, 1);
    //        if (dictionary[character.CharacterName].food == 2 && collect.button1.name == "Food") InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, 2);

    //        i++;
    //    }

    //}

    //private void Save(object sender, System.EventArgs e)
    //{
    //    ActionIsClickable?.Invoke(this, new EventArgs());
    //    PopupAction popup = InstantiatedPopup.GetComponent<PopupAction>();
    //    float Slider1Value = popup.GetSliderValue(1);
    //    float Slider2Value = popup.GetSliderValue(2);
    //    float Slider3Value = popup.GetSliderValue(3);
    //    float StartSlider1Value = popup.GetStartSliderValue(1);
    //    float StartSlider2Value = popup.GetStartSliderValue(2);
    //    float StartSlider3Value = popup.GetStartSliderValue(3);

    //    if (StartSlider1Value != Slider1Value)
    //    {
    //        CheckSliderValueAndChangeStuff(0, StartSlider1Value, Slider1Value);
    //        if (actionType == ActionType.collect) pos.SetCollectData(PartyHandler.PartySession[0].CharacterName, popup.GetImageName(), Slider1Value);
    //    }
    //    if (StartSlider2Value != Slider2Value)
    //    {
    //        CheckSliderValueAndChangeStuff(1, StartSlider2Value, Slider2Value);
    //        if (actionType == ActionType.collect) pos.SetCollectData(PartyHandler.PartySession[1].CharacterName, popup.GetImageName(), Slider2Value);
    //    }
    //    if (StartSlider3Value != Slider3Value)
    //    {
    //        CheckSliderValueAndChangeStuff(2, StartSlider3Value, Slider3Value);
    //        if (actionType == ActionType.collect) pos.SetCollectData(PartyHandler.PartySession[2].CharacterName, popup.GetImageName(), Slider2Value);
    //    }

    //    bool Done = true;

    //    foreach (var marker in MarkerHandler2.dictionary)
    //    {
    //        if (marker.Value.actionType == ActionType.unknown)
    //        {
    //            Done = false;
    //            break;
    //        }
    //    }

    //    if (Done)
    //    {
    //        ContinueButtonIsClickable?.Invoke(this, new EventArgs());
    //    }
    //    else
    //    {
    //        ContinueButtonIsNotClickable?.Invoke(this, new EventArgs());
    //    }

    //    //Added method to safe the current GameObject (e.g. Island) in the pos object
    //    GetReferingObject();

    //    PopupSave.SaveButtonClicked -= Save;
    //    PopupCancel.CancelButtonClicked -= Cancel;
    //    Destroy(InstantiatedPopup);
    //}

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

    //private void Cancel(object sender, System.EventArgs e)
    //{
    //    PopupSave.SaveButtonClicked -= Save;
    //    PopupCancel.CancelButtonClicked -= Cancel;
    //    ActionIsClickable?.Invoke(this, new EventArgs());
    //    Destroy(InstantiatedPopup);
    //}

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

    private void GetReferingObject()
    {
        if(actionType == ActionType.explore || actionType == ActionType.collect)
        {
            var obj = GetComponent<ExploreIsland>();
            pos.ReferingObject = obj;
        }
        if(actionType == ActionType.build)
        {
            var obj = GetComponent<ItemCard>();
            pos.ReferingObject = obj;
        }
    }
}


