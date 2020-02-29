using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralMarker_Plus2Heart : MonoBehaviour
{
    public GameObject moralMarker;
    private GameObject instatiatedMarker;
    private bool isOccupied;
    // Start is called before the first frame update
    void Start()
    {
        Moral.MoralStateChanged += Moral_MoralStateChanged;
        isOccupied = false;
    }

    private void Moral_MoralStateChanged(object sender, System.EventArgs e)
    {
        MoralState moralState = (MoralState)sender;
        if (moralState == MoralState.Best)
        {
            if (!isOccupied)
            {
                instatiatedMarker = Instantiate(moralMarker, transform);
                isOccupied = true;
            }
        }
        else
        {
            Destroy(instatiatedMarker);
            isOccupied = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
