using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_Commander : MonoBehaviour
{

    [SerializeField] private Image healthbarfill;
    float currentHealth;
    float maxHealth = 100;
    [SerializeField] float movspeed;
   





    void Start()
    {
        currentHealth = maxHealth;
      

    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(movspeed, 0);







        // Movement
       


        if (currentHealth <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            // Death Animation Trigger and Destroying of GO
             GetComponent<Animator>().SetTrigger("Die");
            
            Destroy(gameObject, 0.9f);
            currentHealth = maxHealth;
            
            
            
            
            

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall"))
        {

            
            takeDmg(15); // Taking Dmg


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
