using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    [Tooltip("Empty gameobject added here is where player one will spawn")]
    public Transform respawnZonePlayerOne; 

    [Tooltip("Empty gameobject added here is where player two will spawn")]
    public Transform respawnZonePlayerTwo; 

    //  This function is called from our collision detection script which enables us to have multiple zones where the frogs may need to respawn when touched
    public void Respawn(Collider2D otherObj)
    {
        if (otherObj.tag == "FrogOne" )
        {
            //  Set the frog position to our respawn position
            GameMgr.instance.frogOne.transform.position = respawnZonePlayerOne.position; 
        }
        else if (otherObj.tag == "FrogTwo" )
        {
            //  Set the frog position to our respawn position
            GameMgr.instance.frogTwo.transform.position = respawnZonePlayerTwo.position; 
        }
    }
}
