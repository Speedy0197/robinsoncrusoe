using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    //Generell sehr kompliziert gecoded, muss angepasst werden wenn wir alle charactere + friday und dog haben wollen
    //Morgen mal drüber reden damit ich genauer verstehe was deine Gedanken waren, dann kann ich dir helfen des ein bisschen Kompakter und allgemeiner zu machen

    public GameObject BuildPopup;
    public GameObject BuildTest;
    public GameObject BuildPostion;

    public GameObject CookSlider;

    private bool isClickable = false;

    private Action action;
    private float CookSliderValue = 0;
    private List<Position> positions;

    void Start()
    {
        //Actionphase.InitActionPhase += initActionChanged;
        Actionphase.EndActionPhase += endActionChanged;
        Action.ActionCreated += initActionChanged;
    }

    void OnMouseDown()
    {
        //if (isClickable)
        {
            Debug.Log("Build");
            Instantiate(BuildPopup);
        }
    }

    public void saveAndRemovePopup()
    {

        if (action == null) return;

        positions = action.GetPositions();

        if (CookSliderValue == 0)
        {   //CookSlider als variable speichern -> schneller, übersichtlicher
            if (CookSlider.GetComponent<Slider>().value != 0 && CookSlider.GetComponent<Slider>().value <= action.getNumberOfMoves(Typ.cook))
            {
                CookSliderValue = CookSlider.GetComponent<Slider>().value;
                action.decreaseNumberOfMovesBy(Typ.cook, CookSliderValue);
                foreach (var marker in positions)
                {
                    if (marker.name == Name.cook1 && marker.actionType == ActionType.unknown)
                    {
                        marker.actionType = ActionType.build;
                        marker.value = 1; //TO-Do Get actual value
                        if (CookSliderValue == 1) break;
                    }
                    else if (marker.name == Name.cook2 && marker.actionType == ActionType.unknown)
                    {
                        marker.actionType = ActionType.build;
                        marker.value = 1; //TO-Do Get actual value 
                        if (CookSliderValue == 1) break;
                    }
                }
            }
        }

        else if (CookSliderValue == 1)
        {
            if (CookSlider.GetComponent<Slider>().value == 0)
            {
                CookSliderValue = 0;
                action.increaseNumberOfMovesBy(Typ.cook, 1);
                foreach (var marker in positions)
                {
                    if (marker.name == Name.cook1 && marker.actionType == ActionType.build)
                    {
                        marker.actionType = ActionType.unknown;
                        marker.value = 0;
                        break;

                    }
                    else if (marker.name == Name.cook2 && marker.actionType == ActionType.build)
                    {
                        marker.actionType = ActionType.unknown;
                        marker.value = 0;
                        break;
                    }
                }
            }

            else if (CookSlider.GetComponent<Slider>().value == 2)
            {
                CookSliderValue = 2;
                action.decreaseNumberOfMovesBy(Typ.cook, 1);
                foreach (var marker in positions)
                {
                    if (marker.name == Name.cook1 && marker.actionType == ActionType.unknown)
                    {
                        marker.actionType = ActionType.build;
                        marker.value = 1; //TO-Do Get actual value
                        break;

                    }
                    else if (marker.name == Name.cook2 && marker.actionType == ActionType.unknown)
                    {
                        marker.actionType = ActionType.build;
                        marker.value = 1; //TO-Do Get actual value
                        break;
                    }
                }
            }
        }

        else if (CookSliderValue == 2)
        {
            if (CookSlider.GetComponent<Slider>().value == 0)
            {
                CookSliderValue = 0;
                action.increaseNumberOfMovesBy(Typ.cook, 2);
                foreach (var marker in positions)
                {
                    if (marker.name == Name.cook1 && marker.actionType == ActionType.build)
                    {
                        marker.actionType = ActionType.unknown;
                        marker.value = 0;
                    }
                    else if (marker.name == Name.cook2 && marker.actionType == ActionType.build)
                    {
                        marker.actionType = ActionType.unknown;
                        marker.value = 0;
                    }
                }
            }

            else if (CookSlider.GetComponent<Slider>().value == 1)
            {
                CookSliderValue = 1;
                action.increaseNumberOfMovesBy(Typ.cook, 1);
                foreach (var marker in positions)
                {
                    if (marker.name == Name.cook1 && marker.actionType == ActionType.build)
                    {
                        marker.actionType = ActionType.unknown;
                        marker.value = 0;
                        break;
                    }
                    else if (marker.name == Name.cook2 && marker.actionType == ActionType.build)
                    {
                        marker.actionType = ActionType.unknown;
                        marker.value = 0;
                        break;
                    }
                }
            }
        }

            Debug.Log("MovesLeft Koch: " + action.getNumberOfMoves(Typ.cook));
            Debug.Log("KochSliderValue: " + CookSliderValue);
            BuildPopup.SetActive(false);
            // BuildTest.transform.position = BuildPostion.transform.position;
    }

    private void initActionChanged(object action2, System.EventArgs e)
    {
        action = (Action)action2;
        isClickable = true;
    }

    private void endActionChanged(object sender, System.EventArgs e)
    {
        action = null;
        isClickable = false;
    }
}