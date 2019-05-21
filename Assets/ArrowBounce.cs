using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBounce : MonoBehaviour
{
    public float bouncePixels = 50f;
    public float bounceSpeed = 3f;
    private float minY;
    private float maxY;
    private float startTime;
    private RectTransform rect;

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        minY = rect.anchoredPosition.y;
        maxY = minY + bouncePixels;
        startTime = Time.time;
    }

    void Update()
    {
        float timePassed = Time.time - startTime;
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, minY + (Mathf.Sin(bounceSpeed * timePassed) + 1) / 2 * bouncePixels);
    }
}
