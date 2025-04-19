using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skeleton_Script : MonoBehaviour
{

    [SerializeField] private Image healthbarfill;
    public float currentHealth;
    float maxHealth = 100;
    [SerializeField] private float movespeed;
    

    public bool show_Victory = false;

  

    public float dmg_King;
    private void Awake()
    {
      
        
       
        //sp = FindAnyObjectByType<Skeleton_Spawner>();
    }
    void Start()
    {
        currentHealth = maxHealth;

        // Sequence to Increase Hitpoint for King according to Scene 
        dmg_King = 24 -(SceneManager.GetActiveScene().buildIndex*2); 

    }

    // Update is called once per frame
    void Update()
    {


        // Movement
        GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, 0);


        if (currentHealth <= 0)
        {
            // Death Animation Trigger and Destroying of GO

            
            Destroy(gameObject);
            // Loading Scene according to Which lvl is currently Open
            if (SceneManager.GetActiveScene().buildIndex == 11)
            {

                SceneManager.LoadScene("Game_Complete");

            }
            else
            {
                SceneManager.LoadScene("Lvl_Victory");
               
            }
          
            

        }


    }
    // Collision Detection and Action According to Collided Object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall"))
        {

           
            takeDmg(dmg_King); // Taking Dmg


        }
        if (collision.CompareTag("Wall"))
        {

            Destroy(gameObject);
        }
    }

    // Damage Function
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
