using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class MazeWall : MonoBehaviour
{
    private SpriteRenderer _sRend;

    private void Awake()
    {
        _sRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<bullet>(out _))
        {
            _sRend.color = (collision.gameObject.tag) switch
            {
                "Red" => Color.red,
                "Blue" => Color.blue,
                "Green" => Color.green,
                _ => Color.white
            };

            Destroy(collision.gameObject);
        }
    }
}
