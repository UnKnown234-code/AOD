using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_Knight : MonoBehaviour
{
     
    [SerializeField] private Image healthbarfill;
    float currentHealth;
    float maxHealth = 100;
    [SerializeField]float mspeed;
    
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        GetComponent<Rigidbody2D>().velocity = new Vector2(-mspeed, 0);


        if (currentHealth == 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            // Death Animation Trigger and Destroying of GO
            GetComponent<Animator>().SetTrigger("Die");


            Destroy(gameObject,0.9f);
            //transform.position = new Vector2(13f, -4.1f);
            currentHealth = maxHealth;
            
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall"))
        {

            //Destroy(collision.gameObject);
            takeDmg(20); // Taking Dmg


        }
        if (collision.CompareTag("Wall"))
        {

            Destroy(gameObject);
        }
    }


    void takeDmg(float amount)
    {
        currentHealth -= amount; // Taking Health away
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        // Updating The Health Bar
        healthbarfill.fillAmount = currentHealth / maxHealth; 
    }
    }
    