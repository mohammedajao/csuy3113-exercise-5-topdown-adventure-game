using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public int score = 0;

    public List<Collectible> collectibles;
    private List<Collectible> _collectiblesRemaining;

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
        score += 1;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
