using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_ui : MonoBehaviour
{
    public void ResetTheGame()
    {
        SceneManager.LoadScene("BaseScene"); 
        print("The button is working.");
    }

    
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Start_Scene");
    }
}
