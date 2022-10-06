using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if(other.tag == "Player") {
            Debug.Log("Playersdsd");
            Events.onPickup.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player") {
            Events.onPickup.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
