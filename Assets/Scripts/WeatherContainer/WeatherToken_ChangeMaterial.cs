using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherToken_ChangeMaterial : MonoBehaviour
{
    public Material Storm;
    public Material Rain;
    public Material Snow;

    private MeshRenderer renderer;
    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterialTo(WeatherToken token)
    {
        if(token == WeatherToken.Rain)
        {
            renderer.material = Rain;
            return;
        }
        if(token == WeatherToken.Snow)
        {
            renderer.material = Snow;
            return;
        }
        renderer.material = Storm;
    }
}

public enum WeatherToken
{
    Storm,
    Rain,
    Snow
}
