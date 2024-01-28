using System.Collections;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D Rb;
    public float force;
    public GameObject wall;
    public Fog FogRef;
    public Transform secondaryFog;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    public float lifeTime;
    public GameObject[] splash;
    public Vector2 difference;
    public SpriteRenderer sRender;
    public SpriteRenderer thisRend;
    public GameObject paint;
    public CircleCollider2D circleCollider;
    public Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        circleCollider = GetComponent<CircleCollider2D>();
        size = circleCollider.bounds.size;
        Rb = GetComponent<Rigidbody2D>();
        thisRend = GetComponent<SpriteRenderer>();
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
        //Debug.Log(Rb.velocity);
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

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Normal of the first point: " + collision.contacts[0].normal);
            if (collision.contacts[0].normal.x == 1) //left
            {
                paint = Instantiate(splash[0], transform.position, Quaternion.identity);
                paint.transform.position = new Vector3(paint.transform.position.x - (size.x * 2), paint.transform.position.y, paint.transform.position.z);
                paint.GetComponent<SpriteRenderer>().color = thisRend.color;
            }
            else if ((collision.contacts[0].normal.x == -1))  //right
            {
                paint = Instantiate(splash[1], transform.position, Quaternion.identity);
                paint.transform.position = new Vector3(paint.transform.position.x + (size.x * 2), paint.transform.position.y, paint.transform.position.z);
                paint.GetComponent<SpriteRenderer>().color = thisRend.color;
            }
            else if (collision.contacts[0].normal.y == -1)  //up
            {
                paint = Instantiate(splash[2], transform.position, Quaternion.identity);
                paint.transform.position = new Vector3(paint.transform.position.x, paint.transform.position.y + (size.y * 2), paint.transform.position.z);
                paint.GetComponent<SpriteRenderer>().color = thisRend.color;
            }
            else if (collision.contacts[0].normal.y == 1)  //down
            {
                paint = Instantiate(splash[3], transform.position, Quaternion.identity);
                paint.transform.position = new Vector3(paint.transform.position.x, paint.transform.position.y - (size.y * 2), paint.transform.position.z);
                paint.GetComponent<SpriteRenderer>().color = thisRend.color;
            }
            DestroyBullet();
        }

        /*private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall"))
            {
                wall = collision.gameObject;
                if (wall != null)
                {

                    if (Mathf.Abs(Rb.velocity.x) > Mathf.Abs(Rb.velocity.y))
                    {
                        if (Rb.velocity.x > 0)
                        {
                            Debug.Log("right");
                        }
                        else if (Rb.velocity.x < 0)
                        {
                            Debug.Log("left");
                        }
                    }
                    else if (Mathf.Abs(Rb.velocity.x) < Mathf.Abs(Rb.velocity.y))
                    {
                        if (Rb.velocity.y > 0)
                        {
                            Debug.Log("up");
                        }
                        else if (Rb.velocity.y < 0)
                        {
                            Debug.Log("down");
                        }
                    }


                    difference = wall.transform.position - gameObject.transform.position;

                    Debug.Log(difference);
                    if (.5f < Mathf.Abs(difference.x) && Mathf.Abs(difference.x) < .6f)
                    {
                        if (Mathf.Abs(difference.x) - Mathf.Abs(difference.y) > 0)
                        {

                        }
                    }
                    //Instantiate(splash[0], transform.position, Quaternion.identity);
                }
                DestroyBullet();
            }
        }*/
    }
}
