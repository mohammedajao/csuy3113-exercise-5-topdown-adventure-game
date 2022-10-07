using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // take damage when hit by enemy
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            TakeTrueDamage(10);
        }
    }

    // check if player is dead and then prompt to restart
    private void OnGUI(){
        if(health <= 0){
            GUI.Label(new Rect(10, 10, 100, 20), "You Died!");
            if(GUI.Button(new Rect(10, 30, 100, 20), "Restart")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
    }

    
}
