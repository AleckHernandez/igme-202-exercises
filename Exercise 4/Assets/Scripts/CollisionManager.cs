using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collidable;
    [SerializeField]
    private GameObject playerObject;

    private List<SpriteInfo> sprites;
    private SpriteInfo playerSprite;

    private bool aabb = true;

    public bool AABBCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        bool collision = (spriteB.min.x < spriteA.max.x && spriteB.max.x > spriteA.min.x &&
            spriteB.max.y > spriteA.min.y && spriteB.min.y < spriteA.max.y);

        return collision;
    }

    private void Awake()
    {
        foreach (GameObject obj in collidable)
        {
            Debug.Log(obj);
            sprites.Add(obj.GetComponent<SpriteInfo>());
        }
        playerSprite = playerObject.GetComponent<SpriteInfo>();
    }


    private void Update()
    {
        if (aabb)
        {
            int count = 0;
            foreach (SpriteInfo sprite in sprites)
            {
                bool c = AABBCollision(sprite, playerSprite);
                if (c)
                {
                    count++;
                    sprite.spriteRenderer.color = Color.red;
                }
                else
                {
                    sprite.spriteRenderer.color = Color.white;
                }

            }
            if (count > 0) // if player hit more than 0 objects
            {
                playerSprite.spriteRenderer.color = Color.red; // set color to red
                count = 0; // reset count
            }
            else // player hit no objects
            {
                playerSprite.spriteRenderer.color= Color.white;
            }

        }
    }


    public void SwitchMethods()
    {
        aabb = !aabb;
    }
}
