using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popProcess_Roof : MonoBehaviour
{
    public GameObject popup;
    public Texture2D[] buildingDices;
    public Texture2D[] collectDices;
    public Texture2D[] exploreDices;

    public Text actionText;
    public Text successText;
    public Text damageText;
    public Text cardText;
    public RawImage dice_Success;
    public RawImage dice_Damage;
    public RawImage dice_Card;

    public Button button;

    private bool Success = false;
    private bool Damage = false;
    private bool Card = false;

    private RoofAction_Processing myProcessor;
    private void TaskOnClick()
    {
        Destroy(popup);
        if (Success)
        {
            myProcessor.Build();
        }
        else
        {
            var c = myProcessor.myAction.GetExecutingCharacter();
            if (c is ISideCharacter)
            {
                //Nothing
            }
            else
            {
                CharacterActions.RaiseCharacterDeterminationBy(1, c);
            }
        }

        if (Damage)
        {
            CharacterActions.DamageCharacterBy(1, myProcessor.myAction.GetExecutingCharacter());
        }

        if (Card)
        {
            var c = myProcessor.myAction.GetExecutingCharacter();
            if (c is ISideCharacter)
            {
                CharacterActions.DamageCharacterBy(1, c);
                FindObjectOfType<ActionProcesser>().ProcessNextAction();
            }
            else
            {
                FindObjectOfType<BuildingCard_Deck>().DrawAndShow(true);
            }
        }
        else
        {
            FindObjectOfType<ActionProcesser>().ProcessNextAction();
        }
    }

    public void Process(RoofAction_Processing processor)
    {
        myProcessor = processor;
        PartyActions.ExecutingCharacter = myProcessor.myAction.GetExecutingCharacter();
        button.onClick.AddListener(TaskOnClick);

        actionText.text = "Derzeitige Aktion: Bauen einer Dachverbesserung";
        Success = myProcessor.CheckForSuccess();
        if (Success)
        {
            successText.text = "Bauen erfolgreich";
            dice_Success.texture = buildingDices[1];
        }
        else
        {
            successText.text = "Bauen fehlgeschlagen";
            dice_Success.texture = buildingDices[0];
        }

        Damage = myProcessor.CheckForPlayerDamage();
        if (!Damage)
        {
            damageText.text = "Keine verletzungen";
            dice_Damage.texture = buildingDices[2];
        }
        else
        {
            damageText.text = myProcessor.myAction.GetExecutingCharacter().CharacterName + " erhält 1 Schaden";
            dice_Damage.texture = buildingDices[3];
        }

        Card = myProcessor.CheckForCardDraw();
        if (!Card)
        {
            cardText.text = "Es muss keine Karte gezogen werden";
            dice_Card.texture = buildingDices[2];
        }
        else
        {
            var c = myProcessor.myAction.GetExecutingCharacter();
            if (c is ISideCharacter)
            {
                cardText.text = c.CharacterName + " erhält 1 Schaden";
            }
            else
            {
                cardText.text = "Es muss eine Karte gezogen werden";
            }
            dice_Card.texture = buildingDices[4];
        }
    }
}
