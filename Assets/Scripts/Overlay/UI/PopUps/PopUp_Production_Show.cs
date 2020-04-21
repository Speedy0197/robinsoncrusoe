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

    private IIslandCard card;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);

        SetInfoText();
    }

    private void SetInfoText()
    {
        string info = string.Empty;
        card = FindIslandWithCamp();
        if (card == null) info = "Kein Camp gefunden";
        else
        {
            info = "Ihr campt auf der Insel " + card.ToString() + "\r\n";
            info += "Die Insel bringt euch folgende Ressourcen ein:\r\n";

            info += GetRessourceString();
        }
        infoText.text = info;
    }

    private string GetRessourceString()
    {
        string retVal = string.Empty;
        var ressources = card.GetRessourcesOnIsland();
        foreach (var ressource in ressources)
        {
            if(ressource == RessourceType.Fish || ressource == RessourceType.Parrot)
            {
                retVal += "1 Nahrung \r\n";
            }
            else
            {
                retVal += "1 Holz \r\n";
            }
        }

        return retVal;
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
        var ressources = card.GetRessourcesOnIsland();
        foreach (var ressource in ressources)
        {
            card.GatherRessources(ressource);
        }

        Destroy(popUp);
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
    }
}
