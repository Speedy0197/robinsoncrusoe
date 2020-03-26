using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Production_Show : MonoBehaviour
{
    public GameObject popUp;
    public Text infoText;
    public Button confirm;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);

        SetInfoText();
    }

    private void SetInfoText()
    {
        string info = string.Empty;
        var card = FindIslandWithCamp();
        if (card == null) info = "Kein Camp gefunden";
        else
        {
            info = "Ihr campt auf der Insel " + card.ToString() + "\r\n";
            info += "Die Insel bringt euch folgende Ressourcen ein:\r\n";
            info += "TODO: add ressources";
        }
        infoText.text = info;
    }

    private IIslandCard FindIslandWithCamp()
    {
        var islands = FindObjectsOfType<ExploreIsland>();
        foreach(var island in islands)
        {
            if (island.hasCamp) return island.myCard;
        }
        return null;
    }

    private void TaskOnClick()
    {
        Destroy(popUp);
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
    }
}
