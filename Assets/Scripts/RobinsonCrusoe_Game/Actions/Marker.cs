using System.Collections;
using System.Collections.Generic;


public class Marker
{
    public ActionType actionType { get; set; }

    public float value { get; set; }

    public bool isUsed { get; set; }

    public Marker()
    {
        actionType = ActionType.unknown;
        value = 0;
        isUsed = false;
    }
    
}