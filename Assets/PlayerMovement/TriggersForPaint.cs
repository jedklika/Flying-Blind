using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersForPaint : MonoBehaviour
{
    public Shooter Shot;
    // Start is called before the first frame update
    void Start()
    {
        Shot = GameObject.Find("RotatePoint").GetComponent<Shooter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GreenPaint")
        {
            Shot.hasGreen = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "BluePaint")
        {
            Shot.hasBlue = true;
            Destroy(other.gameObject);
        }
    }
}
