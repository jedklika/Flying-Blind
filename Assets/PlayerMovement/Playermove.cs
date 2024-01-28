using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float moveSpeed;
    float speedX, speedY;
    Rigidbody2D Rb;
    private Animator anim;

    public Fog Fog;
    public Transform secondaryFog;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        secondaryFog.localScale = new Vector2(sightDistance, sightDistance) * 10f;
        StartCoroutine(CheckFogOfWar(checkInterval));
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal")* moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        Vector2 direction = new(speedX, speedY);
        Rb.velocity = direction;

        if (direction != Vector2.zero)
        {
            anim.SetBool("Walking", true);

            float angle = Vector2.SignedAngle(Vector2.up, direction);
            Quaternion newRot = Quaternion.Euler(0, 0, angle);
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
}
