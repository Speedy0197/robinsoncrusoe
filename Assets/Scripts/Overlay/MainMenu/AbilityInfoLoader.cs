using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInfoLoader : MonoBehaviour
{
    public Text abilityName;
    public Text abilityCosts;
    public Text abilityInfoText;

    public void SetAbilityName(string name)
    {
        abilityName.text = name;
    }
    public void SetAbilityCost(string costs)
    {
        abilityCosts.text = costs;
    }
    public void SetAbilityDescription(string info)
    {
        abilityInfoText.text = info;
    }
}
