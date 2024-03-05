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
    void Start()
    {
        Fog = GameObject.Find("FogOfWar").GetComponent<Fog>();
        secondaryFog.localScale = new Vector2(sightDistance, sightDistance) * 10f;
        StartCoroutine(CheckFogOfWar(checkInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            Fog.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
