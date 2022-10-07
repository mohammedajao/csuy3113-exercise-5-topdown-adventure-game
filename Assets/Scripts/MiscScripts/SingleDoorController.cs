using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // GetComponentInChildren<MeshRenderer>()[0].enabled = false;
        Events.onDoorwayTriggerEnter.AddListener(DoorwayOpen);
    }

    private void DoorwayOpen()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
