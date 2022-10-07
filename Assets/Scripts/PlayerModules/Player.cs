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
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentsInChildren<UnityEngine.AI.NavMeshAgent>()[0];
        controller = new CharacterController(playerRigidBody, agent, camera);
        controller.Start();
        Events.playerTakeDamage.AddListener(TakeTrueDamage);
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
            controller.Update();
    }

    public void TakeTrueDamage(int val)
    {
        Debug.Log("Player took damage: " + val);
        health -= val;
        if(health <= 0) {
            alive = false;
        }
    }

    //update keys when collected
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Key")){
            Destroy(other.gameObject);
            PublicVars.Keys++;
        }
        if(other.CompareTag("Enemy")) {
            Debug.Log("Player got hit!");
        }
    }

    // take damage when hit by enemy
    private void OnCollisionEnter(Collision collision){
        Debug.Log("Collision name is: " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Player hit by enemy");
            TakeTrueDamage(10);
        }
    }

    // check if player is dead and then prompt to restart
    void OnGUI(){
        Debug.Log("OnGui called");
        if(health <= 0){
            Debug.Log("Health is less than 0!!");
            GUI.Label(new Rect(10, 10, 100, 20), "You Died!");
            GUI.Label(new Rect(10,10,100,30), "DEAD!");
            if(GUI.Button(new Rect(10, 30,Screen.width-60, Screen.height-200), "Restart")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    
}
