using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public List<Texture2D> sprites;
    void Start()
    {
        int r = Random.Range(0, sprites.Count);
        gameObject.GetComponent<Renderer>().material.mainTexture = sprites[r];
    }
}