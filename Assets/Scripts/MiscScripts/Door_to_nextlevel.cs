using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_to_nextlevel : MonoBehaviour
{
    public string levelToLoad;
    private bool locked = false;
    // private int score;

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
            // if (GameManager.collected_all_coins()){
            //     SceneManager.LoadScene(levelToLoad);
            // }
        }
    }


}
