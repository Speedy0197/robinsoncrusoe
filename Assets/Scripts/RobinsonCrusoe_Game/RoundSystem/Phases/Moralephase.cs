using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moralephase : MonoBehaviour
{
    public GameObject morale_Prefab;
    private PhaseView myView;

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponent<PhaseView>();
        myView.currentPhaseChanged += OnPhaseChange;
    }

    private void OnPhaseChange(object sender, System.EventArgs e)
    {
        if (myView.currentPhase == E_Phase.Morale)
        {
            Debug.Log("Entered Phase: Morale ");
            //Show PopUp
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            Instantiate(morale_Prefab, ui.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
