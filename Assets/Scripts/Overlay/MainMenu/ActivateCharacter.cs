using Assets.Scripts.Overlay.MainMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActivateCharacter : MonoBehaviour, IPointerClickHandler
{
    public Texture2D inactive;
    public Texture2D active;
    public RawImage imageContainer;
    public PartySelector character;

    private bool state = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (state)
        {
            state = false;
            imageContainer.texture = inactive;
            TempoarySettings.RemoveCharacterFromParty(character);
        }
        else if(TempoarySettings.NumberOfSelectedCharacters + 1 <= TempoarySettings.NumberOfPlayers)
        {
            state = true;
            imageContainer.texture = active;
            TempoarySettings.AddCharacterToParty(character);
        }
    }
}
