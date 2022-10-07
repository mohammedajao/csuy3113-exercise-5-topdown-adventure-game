using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDamageScript : MonoBehaviour
{

    public int timer = 3;
    private bool debounce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetDamageTimer() {
        debounce = true;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Collision name is: " + other.name);
        if(other.CompareTag("Enemy")){
            Debug.Log("Player hit by enemy");
            Events.playerTakeDamage.Invoke(10);
        }
    }

    void OnCollisionEnter(Collision collision){
        Debug.Log("Collision name is: " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Player hit by enemy");
            if(debounce) {
                Events.playerTakeDamage.Invoke(10);
                debounce = false;
                Invoke(nameof(ResetDamageTimer), timer);
            }
        }
    }
}
