using Assets.Scripts.Generic;
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

    private Character currentMainCharacter;
    private int lastHealth;
    private int lastDetermination;
    private Texture2D full;
    private Texture2D empty;

    // Start is called before the first frame update
    void Start()
    {
        SetMainCharacter(new Cook());
        lastHealth = 0;
        lastDetermination = 0;
        empty = ImageLoader.LoadPNG("Assets/Images/UI/Empty_Heart.png");
        full = ImageLoader.LoadPNG("Assets/Images/UI/Full_Heart.png");
    }

    // Update is called once per frame
    void Update()
    {
        if(lastHealth != currentMainCharacter.GetCurrentHealth())
        {
            lastHealth = currentMainCharacter.GetCurrentHealth();
            UpdateContainerStatus();
            UpdateMoralArrow();
        }

        if(lastDetermination != currentMainCharacter.GetCurrentAmountOfMoraleTokens())
        {
            var value = currentMainCharacter.GetCurrentAmountOfMoraleTokens();
            lastDetermination = value;
            characterDetermination.text = value.ToString();
        }
    }

    public void SetMainCharacter(Character character)
    {
        lastHealth = 0;
        currentMainCharacter = character;
        characterName.text = currentMainCharacter.GetCharacterName();
        UpdateNumberOfVisibleContainers();
        UpdateContainerStatus();
    }

    private void UpdateContainerStatus()
    {
        int tempAmount = currentMainCharacter.GetCurrentHealth();
        for(int i = currentMainCharacter.GetMaxHealth() - 1; i >= 0; i--)
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
        var maxHealth = currentMainCharacter.GetMaxHealth();
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
        if (currentMainCharacter.IsPreMoralChange())
        {
            moralArrow.color = new Color(255, 255, 255, 255);
        }
        else
        {
            moralArrow.color = new Color(255, 255, 255, 0);
        }
    }
}
