using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatCardHolder : MonoBehaviour
{
    public ThreatCard ThreatCard { get; set; }
    public ThreatLevel ThreatLevel { get; set; }
}

public enum ThreatLevel
{
    High,
    Low
}
