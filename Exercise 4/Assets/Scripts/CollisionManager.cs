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

    private bool AABBCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        return (spriteB.min.x < spriteA.max.x && spriteB.max.x > spriteA.min.x &&
            spriteB.max.y > spriteA.min.y && spriteB.min.y < spriteA.max.y);
    }

    private bool CircleCollision(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        Vector3 dVec = spriteA.pos - spriteB.pos; // distance vector
        float dist = dVec.magnitude; // magnitude of distance vector
        return dist < (spriteA.radius + spriteB.radius);
    }

    private void Awake()
    {
        sprites = new List<SpriteInfo>();
        foreach (GameObject obj in collidable)
        {
            sprites.Add(obj.GetComponent<SpriteInfo>());
        }
        playerSprite = playerObject.GetComponent<SpriteInfo>();
    }


    private void Update()
    {
        int count = 0;
        foreach (SpriteInfo sprite in sprites)
        {
            bool c;
            if (aabb) // if using AABB method
            {
                c = AABBCollision(sprite, playerSprite);
            }
            else // use circle method
            {
                c = CircleCollision(sprite, playerSprite);
            }
            sprite.hit = c;
            count += c ? 1 : 0; // adds 1 to count if c is true
        }
        if (count > 0) // if player hit more than 0 objects
        {
            playerSprite.hit = true; // set color to red
            count = 0; // reset count
        }
        else // player hit no objects
        {
            playerSprite.hit = false;
        }

    }


    public void SwitchMethods()
    {
        aabb = !aabb;
        if (aabb)
        {
            Debug.Log("AABB");
        }
        else
        {
            Debug.Log("Circle");
        }
    }

}
