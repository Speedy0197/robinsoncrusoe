using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
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
    public GameObject cardImage;

    public bool useRessources = false;

    public void SetActionContainer(ActionContainer actionContainer)
    {
        container = actionContainer;

        int configuratorIndex = 0; //max = 4
        foreach(var kvp in container.CharacterTokensSpend)
        {
            if (kvp.Key.IsDead) continue;

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

                if(GetTotalValue() > 0) container.HasStoredAction = true;
                else container.HasStoredAction = false;
            }
        }


        DoRessourceCollection();
        AreAllTokensSpend();

        return container;
    }

    private void DoRessourceCollection()
    {
        if (useRessources)
        {
            var tokens = GetTotalValue();
            var costs = GetCosts();
            HandleCosts(costs, tokens);
        }
    }

    private void HandleCosts(RessourceCosts costs, float tokens)
    {
        if (tokens > 0)
        {
            Wood.DecreaseWoodBy(costs.AmountOfWood);
            Fur.DecreaseBy(costs.AmountOfLeather);
            PerishableFood.DecreaseBy(costs.AmountOfFood);
        }
        else if (tokens == 0)
        {
            Wood.IncreaseWoodBy(costs.AmountOfWood);
            Fur.IncreaseBy(costs.AmountOfLeather);
            PerishableFood.IncreaseBy(costs.AmountOfFood);
        }
    }

    private RessourceCosts GetCosts()
    {
        if (container.ActionType == ActionType.upgradeWeapons)
        {
            return new RessourceCosts(1, 0, 0);
        }
        else if (container.ActionType == ActionType.upgradeRoof ||
            container.ActionType == ActionType.upgradeTent ||
            container.ActionType == ActionType.upgradeWall)
        {
            return BuildingCosts.GetBuildingCosts();
        }

        if(container.ActionType == ActionType.build)
        {
            var obj = container.ReferingObject as ItemCard;
            return obj.cardClass.GetRessourceCosts();
        }

        if(container.ActionType == ActionType.preventDanger)
        {
            var obj = container.ReferingObject as ThreatCardHolder;
            var card = obj.ThreatCard.CardClass as IEventCard;
            return card.GetRessourceCosts();
        }

        return new RessourceCosts(0, 0, 0);
    }

    private void AreAllTokensSpend()
    {
        bool allTokensSpend = true;
        foreach(var character in PartyHandler.PartySession)
        {
            if (character.IsDead) continue;
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

    public void SetCardImage(Texture2D image)
    {
        cardImage.SetActive(true);
        cardImage.GetComponent<RawImage>().texture = image;
    }
}
