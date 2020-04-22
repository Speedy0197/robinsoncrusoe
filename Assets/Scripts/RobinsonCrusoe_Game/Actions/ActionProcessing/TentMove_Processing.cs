using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentMove_Processing : MonoBehaviour
{
    public void ProcessTentMove(ActionContainer action)
    {
        var island = action.ReferingObject as ExploreIsland;
        island.CampHere();
    }
}
