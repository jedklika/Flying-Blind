using UnityEngine;

public class YDetector : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public bool seen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seen = true;
        }
        else { seen = false; }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seen = false;
        }
    }
}
