using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DEBUG_PhaseChanger : MonoBehaviour, IPointerClickHandler
{ 
    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO: dont put this in production, find a better way on how to change phases
        var phases = FindObjectOfType<PhaseView>();
        phases.NextPhase();
    }
}

