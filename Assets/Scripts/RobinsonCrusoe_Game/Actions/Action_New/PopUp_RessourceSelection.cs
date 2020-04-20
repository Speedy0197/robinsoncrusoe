using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_RessourceSelection : MonoBehaviour
{
    public GameObject[] ressources;

    public Texture2D foodTexture;
    public Texture2D woodTexture;

    public event EventHandler SelectedRessource;

    public void SetSelection(RessourceType[] selection)
    {
        for(int i = 0; i < selection.Length; i++)
        {
            ressources[i].SetActive(true);
            if(selection[i] == RessourceType.Parrot 
                || selection[i] == RessourceType.Fish)
            {
                ressources[i].GetComponent<RawImage>().texture = foodTexture;
            }
            else
            {
                ressources[i].GetComponent<RawImage>().texture = woodTexture;
            }
            ressources[i].GetComponent<PopUp_RessourceClickHandler>().RessourceType = selection[i];
        }
    }

    public void RaiseEvent(RessourceType selectedRessource)
    {
        SelectedRessource?.Invoke(selectedRessource, new EventArgs());
    }
}
