using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Castle : MonoBehaviour
{
    // Variables
    [SerializeField] Image healthBarFill;
    float maxHealth = 100;
    float CurrentHealth;

    // Death Panel Variables

    [SerializeField] GameObject Death_panel;
    [SerializeField] STOP_Panel panel_Controller;

   

    private void Start()
    {
        // Max Health at Start
        CurrentHealth = maxHealth;
        // Gtting excess to STOP_PANEL script
        panel_Controller = FindAnyObjectByType<STOP_Panel>();
        
    }
    private void Update()
    {
        // Stoping Time and Enemy Movement when Castle Health Reaches Zero or below
        if(CurrentHealth <= 0)
        {
            Time.timeScale = 0;
            Death_panel.SetActive(true);
            
            
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Damage Function For Castle
    void takedmg(float dmg)
    {
        CurrentHealth -= dmg;
        updateHealthBar();
    }
    void updateHealthBar() // Changing HealthBar FillAmount 
    {
        healthBarFill.fillAmount = CurrentHealth / maxHealth;
    }


    // Damage On The basis of Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Skeleton_Minion"))
        {
            takedmg(10);
        }
        if (collision.CompareTag("Skeleton_Knight"))
        {
            takedmg(20);
        }
        if (collision.CompareTag("Skeleton_Commander"))
        {
            takedmg(50);
        }
        if (collision.CompareTag("Skeleton_King"))
        {
            takedmg(100);
        }
    }

    
}
