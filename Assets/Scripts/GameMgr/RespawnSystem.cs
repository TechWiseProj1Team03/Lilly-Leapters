using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    [Tooltip("Add colliders from scene here that you wish to have kill the frog and respawn it.")]
    public List<Collider2D> deathZones; 

     [Tooltip("Empty gameobject added here is where frogs will spawn")]
    public GameObject respawnZone; 

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "PlayerOne" || otherObj.gameObject.tag == "PlayerTwo")
        {
            // Destroy(GameMgr.instance)
        }
    }
}
