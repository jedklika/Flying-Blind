using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public Texture2D fogOfWarTexture;
    public SpriteMask spriteMask;

    private Vector2 worldScale;
    private Vector2Int textureScale;
    public Shooter ColorChange;
    // Start is called before the first frame update
    public void Awake()
    {
        textureScale.x = fogOfWarTexture.width;
        textureScale.y = fogOfWarTexture.height;
        worldScale.x = textureScale.x / 100f * transform.localScale.x;
        worldScale.y = textureScale.y / 100f * transform.localScale.y;
        for(int i =0; i < textureScale.x; i++)
        {
            for (int j =0; j < textureScale.y; j++)
            {
                fogOfWarTexture.SetPixel(i, j, Color.clear);
            }
        }

    }
    private Vector2Int WorldtoPixel(Vector2 position)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        float dx = position.x - transform.position.x;
        float dy = position.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(.5f * textureScale.x + dx * (textureScale.x / worldScale.x));
        pixelPosition.y = Mathf.RoundToInt(.5f * textureScale.y + dx * (textureScale.x / worldScale.x));
        return pixelPosition;
    }
    public void MakeHole(Vector2 position, float holeRadius)
    {
        Vector2Int pixelPosition = WorldtoPixel(position);
        int radius = Mathf.RoundToInt(holeRadius * textureScale.x / worldScale.x);
        int px, nx, py, ny, distance;
        for (int i =0; i < radius; i++)
        {
            distance = Mathf.RoundToInt(Mathf.Sqrt(radius * radius - i * i));
            for(int j =0; j< distance; j++)
            {
                px = Mathf.Clamp(pixelPosition.x + i, 0, textureScale.x);
                nx = Mathf.Clamp(pixelPosition.x - i, 0, textureScale.x);
                py = Mathf.Clamp(pixelPosition.y + i, 0, textureScale.y);
                ny = Mathf.Clamp(pixelPosition.y - i, 0, textureScale.y);

                fogOfWarTexture.SetPixel(px, py, Color.black);
                fogOfWarTexture.SetPixel(nx, py, Color.black);
                fogOfWarTexture.SetPixel(px, ny, Color.black);
                fogOfWarTexture.SetPixel(nx, ny, Color.black);
            }
        }
        fogOfWarTexture.Apply();
        CreateSprite();
    }
    public void CreateSprite()
    {
        spriteMask.sprite = Sprite.Create(fogOfWarTexture, new Rect(0, 0, fogOfWarTexture.width, fogOfWarTexture.height), Vector2.one * .5f, 100f);
    }
}
