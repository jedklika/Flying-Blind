using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public Transform bulletTransform;
    public bool canFire;
    public float fireRate;


    public Fog Fog;
    public Transform secondaryFog;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.WorldToScreenPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (Input.GetKeyDown(KeyCode.Alpha1)&& canFire)
            {
            RedShot();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && canFire)
            {
            GreenShot();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && canFire)
            {
            BlueShot();
            }
        
    }
    void RedShot()
    {
        Instantiate(bullet, bulletTransform.position, Quaternion.identity, transform);
        StartCoroutine(RateOfFire());
    }
    void GreenShot()
    {
        if (Time.time > startTimeBtwShot)
        {
            Instantiate(bullet2, bulletTransform.position, Quaternion.identity, transform);
            StartCoroutine(RateOfFire());
        }
    }
    void BlueShot()
    {
        Instantiate(bullet3, bulletTransform.position, Quaternion.identity, transform);
        StartCoroutine(RateOfFire());
    }
    private IEnumerator RateOfFire()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
