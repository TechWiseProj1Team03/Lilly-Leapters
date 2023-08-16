using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //  Public reference to our respawnSystem, this should not be manually assigned to as the start function will grab it, 
    //  only public to ensure we are grabbing proper script 
    public RespawnSystem respawnSystem; 

    //  The RespawnSystem script must be present in the scene for this to work
    void Start() 
    {
        respawnSystem = GameObject.FindObjectOfType<RespawnSystem>();
    }

    //  Whenever a player triggers the collider we start the respawn sequence
    void OnTriggerEnter2D(Collider2D otherObj) 
    {
        respawnSystem.Respawn(otherObj); 
    }
}
