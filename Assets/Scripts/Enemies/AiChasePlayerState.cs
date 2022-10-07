using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    public float maxTime = 1f;
    public float maxDistance = 0.5f;
    float timer = 0.0f;

    public AiStateId GetId() {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent) {
        
    }

    public void Update(AiAgent agent) {
        if(!agent.enabled) {
            return;
        }

        Debug.Log("Updating chase player");


        timer -= Time.deltaTime;

        //         agent.navMeshAgent.SetDestination(agent.playerTransform.position);

        if(!agent.navMeshAgent.hasPath) {
            Debug.Log("Agent no path");
            // agent.navMeshAgent.Warp(agent.playerTransform.position);

        } else {
            agent.navMeshAgent.SetDestination(agent.playerTransform.position);
        }


        Debug.Log("Time is: " + timer);

        if(timer < 0.0f) {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if(direction.sqrMagnitude > maxDistance * maxDistance) {
                if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial) {
                    agent.navMeshAgent.SetDestination(agent.playerTransform.position);
                }
            }
        }
        timer = maxTime;
    }

    public void Exit(AiAgent agent) {

    }
}
