using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Levels : MonoBehaviour
{
   

// Level Loading Function for Buttons in Level Menu
    public void lvl1()
    {
        SceneManager.LoadScene(2);
    }

    public void lvl2()
    {
        SceneManager.LoadScene(3);
    }

    public void lvl3()
    {
        SceneManager.LoadScene(4);
    }

    public void lvl4()
    {
        SceneManager.LoadScene(5);
    }

    public void lvl5()
    {
        SceneManager.LoadScene(6);
    }

    public void lvl6()
    {
        SceneManager.LoadScene(7);
    }

    public void lvl7()
    {
        SceneManager.LoadScene(8);
    }

    public void lvl8()
    {
        SceneManager.LoadScene(9);
    }

    public void lvl9()
    {
        SceneManager.LoadScene(10);
    }
    public void lvl10()
    {
        SceneManager.LoadScene(11);
    }

    // Final Victory Scene Finish Button
    public void Last_Finish()
    {
        SceneManager.LoadScene(0);
    }

    // Defeat Panel Button Function
    public void to_lvls()
    {
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
