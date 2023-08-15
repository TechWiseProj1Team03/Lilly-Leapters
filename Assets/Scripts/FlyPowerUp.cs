using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPowerUp : MonoBehaviour, Interactable
{
    public IFrogMovement frog;

    public void Interact()
    {
        frog.ActivateFlyPowerUp(); // Allow double jump
        Destroy(gameObject);       // Destroy this object
    }
}
