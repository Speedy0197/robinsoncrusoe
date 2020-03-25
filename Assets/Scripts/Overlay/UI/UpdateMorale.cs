using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMorale : MonoBehaviour
{
    public RawImage imageContainer;

    public Texture2D plus_two_heart;
    public Texture2D plus_two;
    public Texture2D plus_one;
    public Texture2D plus_zero;
    public Texture2D minus_one;
    public Texture2D minus_two;
    public Texture2D minuts_three;

    // Start is called before the first frame update
    void Start()
    {
        Moral.MoralStateChanged += Moral_MoralStateChanged;   
    }

    private void Moral_MoralStateChanged(object sender, System.EventArgs e)
    {
        var morale = (MoralState)sender;
        if (morale == MoralState.Best) imageContainer.texture = plus_two_heart;
        else if (morale == MoralState.Better) imageContainer.texture = plus_two;
        else if (morale == MoralState.Good) imageContainer.texture = plus_one;
        else if (morale == MoralState.Neutral) imageContainer.texture = plus_zero;
        else if (morale == MoralState.Bad) imageContainer.texture = minus_one;
        else if (morale == MoralState.Worse) imageContainer.texture = minus_two;
        else if (morale == MoralState.Demoralized) imageContainer.texture = minuts_three;
    }
}
