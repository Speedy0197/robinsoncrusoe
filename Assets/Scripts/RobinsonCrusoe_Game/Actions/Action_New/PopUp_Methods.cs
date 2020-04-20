using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Methods : MonoBehaviour
{
    public GameObject[] tokenConfigurator;
    public ActionContainer container;
    public Button saveButton;
    public Button cancelButton;

    public void SetActionContainer(ActionContainer actionContainer)
    {
        container = actionContainer;

        int configuratorIndex = 0; //max = 4
        foreach(var kvp in container.CharacterTokensSpend)
        {
            tokenConfigurator[configuratorIndex].SetActive(true);
            var component = tokenConfigurator[configuratorIndex].GetComponent<PopUp_CharSettings>();
            component.SetCharacter(kvp.Key);
            component.SetName(kvp.Key.CharacterName);
            component.SetParent(this);
            component.SetSliderValue(kvp.Value);
            component.SetSliderMaxValue(kvp.Key.MaxNumberOfActions);

            configuratorIndex++;
        }
    }

    internal float GetTotalMaxValue()
    {
        return container.ActionCosts;
    }

    internal float GetTotalValue()
    {
        float total = 0;
        foreach(var config in tokenConfigurator)
        {
            var component = config.GetComponent<PopUp_CharSettings>();
            total += component.GetCurrentSliderValue();
        }
        return total;
    }

    public ActionContainer SaveChanges()
    {
        foreach(var config in tokenConfigurator)
        {
            var component = config.GetComponent<PopUp_CharSettings>();
            if (component.ValueChanged())
            {
                container.SetValue(component.Character, Convert.ToInt32(component.GetCurrentSliderValue()));
                component.Character.CurrentNumberOfActions += component.GetDifference();
                container.HasStoredAction = true;
            }
        }

        AreAllTokensSpend();

        return container;
    }

    private void AreAllTokensSpend()
    {
        bool allTokensSpend = true;
        foreach(var character in PartyHandler.PartySession)
        {
            if (character.CurrentNumberOfActions > 0) allTokensSpend = false;
        }

        if (allTokensSpend)
        {
            FindObjectOfType<ContinueButton>().SetClickableTo(true);
        }
        else
        {
            FindObjectOfType<ContinueButton>().SetClickableTo(false);
        }
    }

    public void Cancel()
    {

    }
}
