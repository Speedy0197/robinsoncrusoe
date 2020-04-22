using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_Object : MonoBehaviour
{
    public GameObject prefab;
    private bool instantiated = false;
    public void OnVictory(string text)
    {
        if (instantiated) return;
        var ui = FindObjectOfType<GetUIBase>().GetUI();
        var instance = Instantiate(prefab, ui.transform);
        instantiated = true;

        var component = instance.GetComponent<PopUp_EndGameScreen>();
        component.isVictory = true;
        component.SetText(text);
    }
    public void OnDefeat(string text)
    {
        if (instantiated) return;
        var ui = FindObjectOfType<GetUIBase>().GetUI();
        var instance = Instantiate(prefab, ui.transform);
        instantiated = true;

        var component = instance.GetComponent<PopUp_EndGameScreen>();
        component.isVictory = false;
        component.SetText(text);
    }

    public static void TriggerVictory(string text)
    {
        FindObjectOfType<EndGame_Object>().OnVictory(text);
    }

    public static void TriggerDefeat(string text)
    {
        FindObjectOfType<EndGame_Object>().OnDefeat(text);
    }
}
