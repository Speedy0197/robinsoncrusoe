using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoralUpdate : MonoBehaviour
{
    public Text moralText;
    // Start is called before the first frame update
    void Start()
    {
        string outputString = NewMethod(Moral.GetStartState());
        moralText.text = outputString;
        Moral.MoralStateChanged += Moral_MoralStateChanged;
    }

    private void Moral_MoralStateChanged(object sender, System.EventArgs e)
    {
        MoralState state = (MoralState)sender;
        string outputString = NewMethod(state);
        moralText.text = outputString;
    }

    private static string NewMethod(MoralState state)
    {
        string outputString = "Moral: ";

        if (state == MoralState.Demoralized) outputString += "-3";
        if (state == MoralState.Worse) outputString += "-2";
        if (state == MoralState.Bad) outputString += "-1";
        if (state == MoralState.Neutral) outputString += "0";
        if (state == MoralState.Good) outputString += "+1";
        if (state == MoralState.Better) outputString += "+2";
        if (state == MoralState.Best) outputString += "+2/Herz";
        return outputString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
