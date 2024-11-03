using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public int textureWidth = 256;
    public int textureHeight = 256;
    public float scale = 20f;
    private Renderer rend;
    void Start()
    {
     rend = GetComponent<Renderer>();
     rend.material.mainTexture = GenerateTexture();   
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(textureWidth, textureHeight);

        for (int x = 0; x < textureWidth; x++){
            for (int y = 0; y < textureHeight; y++){
                float xCoord = (float)x / textureWidth * scale;
                float yCoord = (float)y / textureHeight * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                Color color = new Color(sample, sample, sample);

                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }
}
