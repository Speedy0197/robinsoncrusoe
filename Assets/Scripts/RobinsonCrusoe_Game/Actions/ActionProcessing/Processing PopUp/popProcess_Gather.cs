using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popProcess_Gather : MonoBehaviour
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

    private GatheringActions_Processing myProcessor;
    private void TaskOnClick()
    {
        Destroy(popup);
        if (Success)
        {
            myProcessor.island.Explore();
        }
        else
        {
            var c = myProcessor.myAction.GetExecutingCharacter();
            if(c is ISideCharacter)
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
            if(c is ISideCharacter)
            {
                CharacterActions.DamageCharacterBy(1, c);
                FindObjectOfType<ActionProcesser>().ProcessNextAction();
            }
            FindObjectOfType<GatheringCard_Deck>().DrawAndShow(true);
        }
        else
        {
            FindObjectOfType<ActionProcesser>().ProcessNextAction();
        }
    }

    public void Process(GatheringActions_Processing processor)
    {
        myProcessor = processor;
        button.onClick.AddListener(TaskOnClick);

        actionText.text = "Derzeitige Aktion: Sammeln von " + myProcessor.myAction.CollectRessource.ToString() + " auf " + myProcessor.island.myCard.ToString();
        Success = myProcessor.CheckForSuccess();
        if (Success)
        {
            successText.text = "Sammeln erfolgreich";
            dice_Success.texture = collectDices[1];
        }
        else
        {
            successText.text = "Sammeln fehlgeschlagen";
            dice_Success.texture = collectDices[0];
        }

        Damage = myProcessor.CheckForPlayerDamage();
        if (!Damage)
        {
            damageText.text = "Keine verletzungen";
            dice_Damage.texture = collectDices[2];
        }
        else
        {
            damageText.text = myProcessor.myAction.GetExecutingCharacter().CharacterName + " erhält 1 Schaden";
            dice_Damage.texture = collectDices[3];
        }

        Card = myProcessor.CheckForCardDraw();
        if (Card)
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
            dice_Card.texture = collectDices[4];
        }
        else
        {
            cardText.text = "Es muss keine Karte gezogen werden";
            dice_Card.texture = collectDices[2];
        }
    }
}
