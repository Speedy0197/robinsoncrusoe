using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamp_OnClick : MonoBehaviour
{
    public GameObject myIsland;
    private void OnMouseDown()
    {
        Debug.Log("Click");
        var phase = FindObjectOfType<PhaseView>().currentPhase;
        var ui = FindObjectOfType<GetUIBase>();
        if (phase == Assets.Scripts.RobinsonCrusoe_Game.RoundSystem.E_Phase.Night &&
            myIsland.GetComponent<ExploreIsland>().isExplored &&
            !myIsland.GetComponent<ExploreIsland>().hasCamp)
        {
            myIsland.GetComponent<ExploreIsland>().CampHere();

            Wall.HalfValue();
            Roof.HalfValue();
        }
    }
}
