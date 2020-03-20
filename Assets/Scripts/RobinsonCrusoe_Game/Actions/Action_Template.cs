using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_Template : MonoBehaviour
{
    public GameObject popup;  // => PopUpValue Script
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
        InstantiatedPopup = Instantiate(popup);
        pos = new Position();

        //Instantiate PopUp
        //instance.GetComponent(PopUpValues)
        //PopUpValues => Slider, Text, etc.
        PopupSave.SaveButtonClicked += Save;



        //PartyHandler.PartySession => alle charactere
        //Aktualisere Slider anhand von Pos;
        //Pos.GetDictionary()
        //foreach entry in Dictionary
        //if(entry.key = cook) Slider[0].Value = entry.Value
    }

    void OnMouseDown()
    {
        //if (isClickable)
        {
            InstantiatedPopup = Instantiate(popup, popup_position.transform);
            Dictionary<string, int> dictionary = pos.GetDictionary();
            if (dictionary != null)
            {
                int i = 1;
                foreach (var character in PartyHandler.PartySession)
                {
                    GameObject.Find("Slider" + i).GetComponent<Slider>().value = dictionary[character.CharacterName];
                    i++;
                }
            }


        }
    }

    public void Save(object sender, System.EventArgs e)
    {
        PopupAction popup = InstantiatedPopup.GetComponent<PopupAction>();
        float Slider1Value = popup.GetSliderValue(1);

        Debug.Log(Slider1Value);

        float Slider2Value = GameObject.Find("Slider2").GetComponent<Slider>().value;
        float Slider3Value = GameObject.Find("Slider3").GetComponent<Slider>().value;
        
        if (GameObject.Find("Slider1").GetComponent<Slider>().value <= PartyHandler.PartySession[0].CurrentNumberOfActions)
        {

        }
        //  pos = new Position(sender)
        //  pos.ChangeValue(Cook, CookSLider.Value);
        //  pos.ChangeValue(Friday, FridaySlider.Value);
        //  Instantiate Marker ||FindObjectOfType<Marker> Marker.SetPosition(this.transform);
        //  Destroy PopUp
    }

    //public Cancel(): Destroy PopUp

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
