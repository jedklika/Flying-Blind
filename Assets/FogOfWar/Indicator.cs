using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public Fog Fog;
    public Transform secondaryFog;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    // Start is called before the first frame update
}
