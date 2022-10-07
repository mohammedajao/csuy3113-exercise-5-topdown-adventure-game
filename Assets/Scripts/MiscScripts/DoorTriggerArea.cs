using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{

    public LayerMask playerLM;
    public float doorActivationRange;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided" + other.name);
        if(other.tag == "Player") {
            Events.onDoorwayTriggerEnter.Invoke();
        }
    }
}
