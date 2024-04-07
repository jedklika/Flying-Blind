using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class MazeDoor : MonoBehaviour
{
    private SpriteRenderer _sRend;
    public Light2D DoorLight;
    [SerializeField] private GameColor doorColor;
    [SerializeField] private GameColor lightColor;

    private void Awake()
    {
        _sRend = GetComponent<SpriteRenderer>();


        _sRend.color = (doorColor) switch
        {
            GameColor.Red => Color.red,
            GameColor.Blue => Color.blue,
            GameColor.Green => Color.green,
            _ => Color.white
        };
    }
    public void Update()
    {
        switch (doorColor)
        {
            case GameColor.Red:
                DoorLight.color = Color.red;
                break;
                
            case GameColor.Blue:
                DoorLight.color = Color.blue; 
                break;
                
            case GameColor.Green:
                DoorLight.color = Color.green; 
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<bullet>(out _))
        {
            switch (collision.gameObject.tag)
            {
                case "Red":
                    if (doorColor == GameColor.Red) Destroy(this.gameObject);
                    break;

                case "Blue":
                    if (doorColor == GameColor.Blue) Destroy(this.gameObject);
                    break;

                case "Green":
                    if (doorColor == GameColor.Green) Destroy(this.gameObject);
                    break;
            }

            Destroy(collision.gameObject);
        }
    }
}

public enum GameColor
{
    Red,
    Green,
    Blue,
}
