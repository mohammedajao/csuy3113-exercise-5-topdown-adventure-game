using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement
{
    private Camera camera;
    private Vector3 movementInput;
    public Rigidbody playerRigidBody;
    public NavMeshAgent agent;

    public PlayerMovement(Rigidbody rb, NavMeshAgent agnt, Camera cmra)
    {
        agent = agnt;
        camera = cmra;
        playerRigidBody = rb;
        groundLM = glm;
    }

    void GatherInput()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    // Start is called before the first frame update
    public void Start()
    {
    
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
