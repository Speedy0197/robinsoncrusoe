using Assets.Scripts.Player;
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

    private bool isClickable = true; //TO-DO Change back to false

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

    private void CheckSliderValueAndChangeStuff(int characterNr, float StartSliderValue, float SliderValue)
    {
        string characterName = PartyHandler.PartySession[characterNr].CharacterName;
        pos.SetDictionary(characterName, SliderValue);
        PartyHandler.PartySession[characterNr].CurrentNumberOfActions += (int)(StartSliderValue - SliderValue);

        if (StartSliderValue < SliderValue)
        {
            if (SliderValue - StartSliderValue == 1)
            {
                MarkerHandler2.SetMarkerByName(characterName, this.transform.position, ActionType.build, 1);
            }
            else if (SliderValue - StartSliderValue == 2)
            {
                MarkerHandler2.SetMarkerByName(characterName, this.transform.position, ActionType.build, 1);
                MarkerHandler2.SetMarkerByName(characterName, this.transform.position, ActionType.build, 1);
            }
        }
        else if (StartSliderValue > SliderValue)
        {
            if (StartSliderValue - SliderValue == 1)
            {
                MarkerHandler2.RemoveMarkerByName(characterName, this.transform.position);
            }
            else if (StartSliderValue - SliderValue == 2)
            {
                MarkerHandler2.RemoveMarkerByName(characterName, this.transform.position);
                MarkerHandler2.RemoveMarkerByName(characterName, this.transform.position);
            }

        }
    }
}


