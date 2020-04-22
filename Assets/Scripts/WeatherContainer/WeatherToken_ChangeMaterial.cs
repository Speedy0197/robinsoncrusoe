using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherToken_ChangeMaterial : MonoBehaviour
{
    public Material Storm;
    public Material Rain;
    public Material Snow;

    private void Start()
    {
        
    }

    public void ChangeMaterialTo(WeatherToken token)
    {
        var myRenderer = GetComponent<MeshRenderer>();
        if (token == WeatherToken.Rain)
        {
            myRenderer.material = Rain;
            return;
        }
        if(token == WeatherToken.Snow)
        {
            myRenderer.material = Snow;
            return;
        }
        myRenderer.material = Storm;
    }
}

public enum WeatherToken
{
    Storm,
    Rain,
    Snow
}
