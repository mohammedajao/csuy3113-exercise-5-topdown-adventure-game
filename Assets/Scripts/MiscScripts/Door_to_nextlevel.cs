using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_to_nextlevel : MonoBehaviour
{
    public string levelToLoad;
    // defaulting to true for testing
    private bool locked = true;

    // for some reason, this isn't working properly
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!locked)
            {
                SceneManager.LoadScene(levelToLoad);
            } 
            // else {
            //     if (PublicVars.Keys > 0){
            //         PublicVars.Keys--;
            //         SceneManager.LoadScene(levelToLoad);
            //     }
            // }
        }
    }

    // handler to unlock door
    public void UnlockDoor(){
        locked = false;
        // Debug.Log("Door unlocked");
    }


}
