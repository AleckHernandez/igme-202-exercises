using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    private bool moveable;

    private SpriteRenderer spriteRenderer;

    public float radius;

    public Vector3 min, max;

    public Vector3 pos;

    public bool hit = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateBounds();
        

        radius = spriteRenderer.bounds.size.x / 2;
    }

    private void Update()
    {
        if (hit)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
        if (moveable)
        {
            UpdateBounds();
        }
    }

    private void UpdateBounds()
    {
        pos = transform.position;
        min = spriteRenderer.bounds.min;
        max = spriteRenderer.bounds.max;
    }
}
