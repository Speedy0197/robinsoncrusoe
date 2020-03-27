using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Threat_Show : MonoBehaviour
{
    public GameObject popUp;

    public Text cardNameText;
    public RawImage cardFaceContainer;
    public Text descriptionText;
    public Button confirmButton;

    private ICard myCard;
    private Texture2D myCardTexture;

    // Start is called before the first frame update
    void Start()
    {
        confirmButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        myCard.ExecuteEvent();
        EndPhase();
    }

    public void SetCard(ICard card, Texture2D cardTexture)
    {
        if (card == null) EndPhase();
        else
        {
            Debug.Log(card);
            myCard = card;
            myCardTexture = cardTexture;
            cardFaceContainer.texture = myCardTexture;
            cardNameText.text = myCard.ToString();
            descriptionText.text = myCard.GetCardDescription();
        }
    }

    private void EndPhase()
    {
        Destroy(popUp);
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
    }
}
