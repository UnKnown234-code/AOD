using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_Minion : MonoBehaviour
{
    int hit = 0;
    public bool canDestroy = false;
    [SerializeField] float movespeed;

    Skeleton_Script sk;
    Skeleton_Spawner spawner;

    private void Awake()
    {
        sk = FindObjectOfType<Skeleton_Script>(); // Finds the first instance of Skeleton_Spawner
        spawner = FindAnyObjectByType<Skeleton_Spawner>();
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, 0); // Movement


        // Using Object Pooling to Spawn Minions after the Hitt The Fireball
        if (hit == 2)
        {
            if (spawner.canSpawn)
            {
                transform.position = new Vector2(24, -3);
                hit = 0;
                spawner.minion_spawned++;
            }
            else
            {
                Destroy(gameObject);
            }

           
        }
    }


    // Collision Detection and Action After Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.position = new Vector2(24, -3);
        }
        if (collision.CompareTag("FireBall"))
        {
            hit++;
        
        }
    }


    


}
