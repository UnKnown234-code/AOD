using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STOP_Panel : MonoBehaviour
{
    [SerializeField] GameObject panel;
   
    

  

    public void Continue()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
       

    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        
       

    }
    
    // Death Oanel Function Controller
    public void Death_TryAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;


    }
    public void Death_Leave()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // Victory Panel Controller
 

    public void victory_Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Victory_Leave()
    {
        SceneManager.LoadScene(0);
    }
  
}
