using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D Rb;
    public float force;
    
    public Fog FogRef;
    public Transform secondaryFog;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        Rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        FogRef = GameObject.Find("FogOfWar").GetComponent<Fog>();
        Invoke("DestroyBullet", lifeTime);

        secondaryFog.localScale = new Vector2(sightDistance, sightDistance) * 10f;
        StartCoroutine(CheckFogOfWar(checkInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            FogRef.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
