using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popProcess_Build : MonoBehaviour
{
    public Texture2D[] buildingDices;
    public Texture2D[] collectDices;
    public Texture2D[] exploreDices;

    public Text actionText;
    public Text successText;
    public Text damageText;
    public Text cardText;

    public Button button;

    private BuildingHelper_Processing myProcessor;
    private void TaskOnClick()
    {
        if (myProcessor.CheckForSuccess())
        {
            myProcessor.item.Research();
        }
        else
        {
            CharacterActions.RaiseCharacterDeterminationBy(1, myProcessor.myAction.ExecutingCharacter);
        }

        if (myProcessor.CheckForPlayerDamage())
        {
            CharacterActions.DamageCharacterBy(1, myProcessor.myAction.ExecutingCharacter);
        }

        if (!myProcessor.CheckForCardDraw())
        {
            FindObjectOfType<BuildingCard_Deck>().DrawAndShow();
            //idea: put param into draw and show, to determin wether processor.nextStep has to be called or not
        }
    }

    public void Process(BuildingHelper_Processing processor)
    {
        myProcessor = processor;
        button.onClick.AddListener(TaskOnClick);

        actionText.text = "Derzeitige Aktion: Bauen von " + myProcessor.item.ToString();
        if (myProcessor.CheckForSuccess())
        {
            successText.text = "Bauen erfolgreich";
        }
        else
        {
            successText.text = "Bauen fehlgeschlagen";
        }

        if (!myProcessor.CheckForPlayerDamage())
        {
            damageText.text = "Keine verletzungen";
        }
        else
        {
            damageText.text = myProcessor.myAction.ExecutingCharacter.CharacterName + " erhält 1 Schaden";
        }

        if (!myProcessor.CheckForCardDraw())
        {
            cardText.text = "Es muss keine Karte gezogen werden";
        }
        else
        {
            cardText.text = "Es muss eine Karte gezogen werden";
        }
    }
}
