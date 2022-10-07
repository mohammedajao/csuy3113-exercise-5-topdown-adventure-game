using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;
    private UnityEngine.AI.NavMeshAgent agent;
    public Rigidbody playerRigidBody;
    public Camera camera;
    
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentsInChildren<UnityEngine.AI.NavMeshAgent>()[0];
        controller = new CharacterController(playerRigidBody, agent, camera);
        controller.Start();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Update();
    }

    void TakeTrueDamage(int val)
    {
        health -= val;
    }

    //update keys when collected
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Key")){
            Destroy(other.gameObject);
            PublicVars.Keys++;
        }
    }
}
