using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{

    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    public Transform playerTransform;
    public int maxSightDistance = 10;
    private AiState chase;
    private AiState idle;

    // Start is called before the first frame update
    void Start()
    {
        if(playerTransform == null) {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform.Find("Body").transform;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AiStateMachine(this);
        chase = new AiChasePlayerState();
        idle = new AiIdleState();
        stateMachine.RegisterState(chase);
        stateMachine.RegisterState(idle);
        stateMachine.ChangeState(idle.GetId());
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log("Distance is: " + distance);
        if(distance < maxSightDistance) {
            stateMachine.ChangeState(chase.GetId());
        } else {
            stateMachine.ChangeState(idle.GetId());
        }
    }
}
