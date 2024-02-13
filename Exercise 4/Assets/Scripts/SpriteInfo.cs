using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool moveable;

    //public float minX, minY, maxX, maxY;

    public float radius;

    public Vector3 min, max;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateBounds();
    }

    private void Update()
    {
        if (moveable)
        {
            UpdateBounds();
        }
    }

    private void UpdateBounds()
    {
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }
}
