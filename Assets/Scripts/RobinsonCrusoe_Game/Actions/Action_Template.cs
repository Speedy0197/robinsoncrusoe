using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_Template : MonoBehaviour
{
    public GameObject popup;
    public GameObject popup_position;

    public enum ActionType
    {
        unknown,
        build,
        collect,
        explore,
    }
    //IEventCard hintergrund Klasse
    public Position pos = null;
    //Position:
    //  ctor: Dictionary<Typ, int> = new Dictionary(); foreach character in Party do Dictionary.Add(character, 0)
    //  Dictionary.Add(CharacterTyp.Cook, AmountOfActionsSpend);
    //  ActionType
    //  ChangeValue(character, value) Dictionary[character].Value = value;
    //  IEventCard hintergrund Klasse
    //GameObject Marker

    //public static event SetClickable
    private GameObject InstantiatedPopup;

    public float test;
    // Start is called before the first frame update
    void Start()
    {
        
        pos = new Position();

        //Instantiate PopUp
        //instance.GetComponent(PopUpValues)
        //PopUpValues => Slider, Text, etc.




        //PartyHandler.PartySession => alle charactere
        //Aktualisere Slider anhand von Pos;
        //Pos.GetDictionary()
        //foreach entry in Dictionary
        //if(entry.key = cook) Slider[0].Value = entry.Value
    }

    void OnMouseDown()
    {
        //if (isClickable) TO-DO
        {
            
            InstantiatedPopup = Instantiate(popup, popup_position.transform);
            PopupSave.SaveButtonClicked += Save;
            PopupCancel.CancelButtonClicked += Cancel;
            Dictionary<string, float> dictionary = pos.GetDictionary();
                        
            if (dictionary != null)
            {
                int i = 1;
                foreach (var character in PartyHandler.PartySession)
                {
                    InstantiatedPopup.GetComponent<PopupAction>().SetSliderValue(i, dictionary[character.CharacterName]);
                    i++;
                }
            }


        }
    }

    public void Save(object sender, System.EventArgs e)
    {
        PopupAction popup = InstantiatedPopup.GetComponent<PopupAction>();
        float Slider1Value = popup.GetSliderValue(1);
        float Slider2Value = popup.GetSliderValue(2);
        float Slider3Value = popup.GetSliderValue(3);

        
        pos.SetDictionary(PartyHandler.PartySession[1].CharacterName, Slider2Value);
        pos.SetDictionary(PartyHandler.PartySession[2].CharacterName, Slider3Value);

        if (popup.GetStartSliderValue(1) != Slider1Value)
        {
            pos.SetDictionary(PartyHandler.PartySession[0].CharacterName, Slider1Value);
            PartyHandler.PartySession[0].CurrentNumberOfActions += (int)(popup.GetStartSliderValue(1) - Slider1Value);
        }
        PopupSave.SaveButtonClicked -= Save;
        PopupCancel.CancelButtonClicked -= Cancel;
        Destroy(InstantiatedPopup);
        //  pos = new Position(sender)
        //  pos.ChangeValue(Cook, CookSLider.Value);
        //  pos.ChangeValue(Friday, FridaySlider.Value);
        //  Instantiate Marker ||FindObjectOfType<Marker> Marker.SetPosition(this.transform);
        //  Destroy PopUp
    }

    public void Cancel(object sender, System.EventArgs e)
        {
            PopupSave.SaveButtonClicked -= Save;
            PopupCancel.CancelButtonClicked -= Cancel;
            Destroy(InstantiatedPopup);
        }

    //OnSlider.OnValueChange{
    //  if(currentValue > maxValue) currentValue = maxValue;
    //}


    //if(hintergrundKlasse is IInsel){
    /* var inselCard = hintergurndKlasse as IInsel;
     * inselCard.IsExplored, .Explore(), .Gather(),
     * */

    //OnClickableChanged(sender => bool value) 

    //Reset(){ 
    // pos = null
    // Marker.ReturnToBasePosition();
    //}
}
