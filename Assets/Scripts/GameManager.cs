using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public List<Collectible> collectibles;
    private List<Collectible> _collectiblesRemaining;
    private int coins_left;
    public Door_to_nextlevel door;

    void onEnable()
    {
        _collectiblesRemaining = new List<Collectible>(collectibles);
        foreach(var coll in _collectiblesRemaining) {
            Events.onPickup.AddListener(HandlePickup);
        }
    }

    void onDisable() 
    {
        foreach(var coll in _collectiblesRemaining) {
            Events.onPickup.RemoveListener(HandlePickup);
        }
    }

    public void HandlePickup(Collectible coll) 
    {
        coins_left -= 1;
    }




    private void Awake()
    {
        if(current == null)
            current = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        onEnable();
        coins_left = collectibles.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(coins_left == 0) {
            door.UnlockDoor();
        }
    }

    // // function to check if all coins are collected
    // public bool collected_all_coins()
    // {
    //     if(coins_left == 0)
    //         return true;
    //     else
    //         return false;
    // }

    // public void getGameManger()
    // {
    //     Debug.Log("GameManager");
    // }
}
