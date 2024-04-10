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
            GameColor.Blue => new Color(0.07843138f, 0.4705882f,1,1),
            GameColor.Green => new Color(0.07734208f, 0.4313726f, 0,1),
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
                DoorLight.color = new Color(0.07843138f, 0.4705882f, 1, 1);
                break;
                
            case GameColor.Green:
                DoorLight.color = new Color(0.07734208f, 0.4313726f, 0, 1);
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
