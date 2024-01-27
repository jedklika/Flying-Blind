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


    
}
