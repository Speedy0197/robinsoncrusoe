using Assets.Scripts.Generic;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    public Text characterName;
    public Text characterDetermination;
    public RawImage[] heartContainer;
    public RawImage moralArrow;
    public RawImage activePlayerMarker;
    public Texture2D full;
    public Texture2D empty;

    private Character currentMainCharacter;
    private int lastHealth;
    private int lastDetermination;
    private bool lastActive;

    // Start is called before the first frame update
    void Start()
    {
        SetMainCharacter(PartyActions.GetActiveCharacter());
        lastHealth = 0;
        lastDetermination = 0;
        lastActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastHealth != currentMainCharacter.CurrentHealth)
        {
            lastHealth = currentMainCharacter.CurrentHealth;
            UpdateContainerStatus();
            UpdateMoralArrow();
        }

        if(lastDetermination != currentMainCharacter.CurrentDetermination)
        {
            var value = currentMainCharacter.CurrentDetermination;
            lastDetermination = value;
            characterDetermination.text = value.ToString();
        }

        if (currentMainCharacter.IsActiveCharacter && lastActive != currentMainCharacter.IsActiveCharacter)
        {
            activePlayerMarker.color = new Color(255, 255, 255, 255);
            lastActive = currentMainCharacter.IsActiveCharacter;
        }
        else if(lastActive != currentMainCharacter.IsActiveCharacter && !currentMainCharacter.IsActiveCharacter)
        {
            activePlayerMarker.color = new Color(255, 255, 255, 0);
            lastActive = currentMainCharacter.IsActiveCharacter;
        }
    }

    public void SetMainCharacter(Character character)
    {
        lastHealth = 0;
        currentMainCharacter = character;
        characterName.text = currentMainCharacter.CharacterName;
        UpdateNumberOfVisibleContainers();
        UpdateContainerStatus();
    }

    private void UpdateContainerStatus()
    {
        int tempAmount = currentMainCharacter.CurrentHealth;
        for(int i = currentMainCharacter.MaxHealth - 1; i >= 0; i--)
        {
            if (tempAmount <= 0)
            {               
                heartContainer[i].texture = empty;
                tempAmount--;
            }
            else
            {              
                heartContainer[i].texture = full;
                tempAmount--;
            }
        }
    }

    private void UpdateNumberOfVisibleContainers()
    {
        var maxHealth = currentMainCharacter.MaxHealth;
        for (int i = 0; i < heartContainer.Length; i++)
        {
            if (maxHealth <= i)
            {
                heartContainer[i].color = new Color(0, 0, 0, 0);
            }
            else
            {
                heartContainer[i].color = new Color(255, 0, 0, 255);
            }
        }
    }

    private void UpdateMoralArrow()
    {
        if (CharacterActions.IsCharacterHealthInPreMoralChangeRange(currentMainCharacter))
        {
            moralArrow.color = new Color(255, 255, 255, 255);
        }
        else
        {
            moralArrow.color = new Color(255, 255, 255, 0);
        }
    }
}
