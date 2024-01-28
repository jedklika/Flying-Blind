using System;
using System.Collections;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed;
    float speedX, speedY;
    Rigidbody2D Rb;
    private Animator anim;

    public Fog Fog;
    public Transform secondaryFog;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    public Vector2 mousePos;
    public Vector2 playerPos;
    public GameObject player;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        secondaryFog.localScale = new Vector2(sightDistance, sightDistance) * 10f;
        StartCoroutine(CheckFogOfWar(checkInterval));
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); ;
        CalculateAngleForAnim(playerPos, mousePos);
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        Vector2 direction = new(speedX, speedY);
        Rb.velocity = direction;

        float ang = AngleBetweenVector2(mousePos, transform.position);


        if (direction != Vector2.zero)
        {
            anim.SetBool("Walking", true);

            //float angle = Vector2.SignedAngle(Vector2.up, direction);
            //Quaternion newRot = Quaternion.Euler(0, 0, angle);
            //transform.rotation = newRot;

            Quaternion newRot = Quaternion.Euler(0, 0, ang);
            transform.rotation = newRot;
        }
        else
        {
            anim.SetBool("Walking", false);
        }

    }
    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            Fog.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
    private void CalculateAngleForAnim(Vector2 me, Vector2 target)
    {
        float angleBetween = AngleBetweenVector2(me, target);

        player.transform.rotation = Quaternion.Euler(0, 0, angleBetween);

    }
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            alive = false;
        }
    }
}
