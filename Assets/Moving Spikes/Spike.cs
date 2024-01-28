using UnityEngine;

public class Spike : MonoBehaviour
{
    public XDetector detecter1;
    public YDetector detecter2;
    public GameObject player;
    public Vector2 playerPos;
    public CircleCollider2D circleCollider;
    Rigidbody2D Rb;
    public float moveSpeed = 2;
    public Vector2 origin;
    public Vector2 currentPos;
    public float Xposition = 0;
    public float Yposition = 0;
    public bool red = false;
    public bool blue = false;
    public bool green = false;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        origin = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        Xposition = player.transform.position.x;
        Yposition = player.transform.position.y;


        if (detecter1.seen && Xposition - gameObject.transform.position.x > 0)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * 1.3f);
        }
        else if ((detecter1.seen && Xposition - gameObject.transform.position.x < 0))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime * 1.3f);
        }
        else if (detecter2.seen && (Yposition - gameObject.transform.position.y > 0))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime * 1.3f);
        }
        else if (detecter2.seen && (Yposition - gameObject.transform.position.y < 0))
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime * 1.3f);
        }
        else if (!detecter1.seen && !detecter2.seen)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, origin, moveSpeed * Time.deltaTime);
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Red") && red)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Blue") && blue)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Green") && green)
        {
            Destroy(gameObject);
        }

        Destroy(collision.gameObject);
    }

}
