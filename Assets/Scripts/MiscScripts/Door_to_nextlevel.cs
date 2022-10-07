using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_to_nextlevel : MonoBehaviour
{
    public string levelToLoad;
    public bool locked = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!locked)
            {
                SceneManager.LoadScene(levelToLoad);
            } else {
                if (PublicVars.Keys > 0){
                    PublicVars.Keys--;
                    SceneManager.LoadScene(levelToLoad);
                }
            }
        }
    }
}