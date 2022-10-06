using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController
{
    public PlayerMovement movementManager;
    // Start is called before the first frame update

    public CharacterController(Rigidbody playerRigidBody, NavMeshAgent agent, Camera camera)
    {
        movementManager = new PlayerMovement(playerRigidBody, agent, camera);
    }

    public void Start()
    {
        movementManager.Start();
    }

    // Update is called once per frame
    public void Update()
    {
        movementManager.Update();
    }
}
