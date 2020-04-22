﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ability : MonoBehaviour, IPointerClickHandler
{
    public GameObject charRef;
    public void OnPointerClick(PointerEventData eventData)
    {
        charRef.GetComponent<HealthView>().UseAbility();
    }
}
