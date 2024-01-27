using UnityEngine;

public class Detecter : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public bool seen = false;
    public float Xposition = 0;
    public float Yposition = 0;
    public GameObject player;
    public Vector2 playerPos;
    public bool Xchecker;
    public bool Ychecker;
    public bool up;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Xchecker)
        {
            Xposition = player.transform.position.x;
        }
        else if (Ychecker)
        {
            Yposition = player.transform.position.y;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seen = true;
        }
        else { seen = false; }

    }

    public void Direction()
    {
        if (Xchecker)
        {
            if (Xposition - gameObject.transform.position.x > 0)
            {
                right = true;
            }
            else
            {
                right = false;
            }

        }

        if (Ychecker)
        {
            if (Yposition - gameObject.transform.position.y > 0)
            {
                up = true;
            }
            else { up = false; }
        }
    }
}
