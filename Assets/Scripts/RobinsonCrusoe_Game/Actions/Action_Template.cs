using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Template : MonoBehaviour
{
    //GameObjecet PopUp => PopUpValue Script
    //enum ActionType 
    //IEventCard hintergrund Klasse
    //Public Position pos = null
    //Position:
    //  ctor: Dictionary<Typ, int> = new Dictionary(); foreach character in Party do Dictionary.Add(character, 0)
    //  Dictionary.Add(CharacterTyp.Cook, AmountOfActionsSpend);
    //  ActionType
    //  ChangeValue(character, value) Dictionary[character].Value = value;
    //  IEventCard hintergrund Klasse
    //GameObject Marker

    //public static event SetClickable

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate PopUp
        //instance.GetComponent(PopUpValues)
        //PopUpValues => Slider, Text, etc.
        //PopUp.EventOnClose += Save

        //PartyHandler.PartySession => alle charactere
        //Aktualisere Slider anhand von Pos;
        //Pos.GetDictionary()
        //foreach entry in Dictionary
        //if(entry.key = cook) Slider[0].Value = entry.Value
    }

    //public Save(sender){
    //  pos = new Position(sender)
    //  pos.ChangeValue(Cook, CookSLider.Value);
    //  pos.ChangeValue(Friday, FridaySlider.Value);
    //  Instantiate Marker ||FindObjectOfType<Marker> Marker.SetPosition(this.transform);
    //  Destroy PopUp
    //}

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
