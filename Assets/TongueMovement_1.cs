using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueMovement_1 : MonoBehaviour
{
    public float tongueLength = 3f;  // Maximum length the tongue can extend
    public float interactionDistance = 2f;  // Distance within which tongue can interact with objects
    public LayerMask interactableLayers;  // Layers that tongue can interact with
    public Animator tongueAnimator;  // Reference to the Animator component
    public FrogMovement frogMovement;
    private Vector2 tongueEnd;  // Calculated end point of the tongue
    public AudioClip toungueSound; 

    void Start()
    {
        // Initialize the tongueAnimator reference
        // tongueAnimator = GetComponent<Animator>();  // Fetch the Animator component on this GameObject (for now we just set manually in editor)
        if (!tongueAnimator)  // Check if Animator component is present
        {
            Debug.LogError("No Animator component found on this GameObject!", this);  // Log error if Animator is missing
        }
    }

    void Update()
    {
        tongueAnimator.SetBool("isFiring", false);
        if (Input.GetKeyDown(KeyCode.Return))  // Check for Enter key press
        {
            HandleTongueExtension();
            AudioMgr.instance.PlaySound(toungueSound);   // Handle the tongue extension logic
        }
        else if (Input.GetKeyUp(KeyCode.Return))  // Check for Enter key release
        {
            HandleTongueRetraction();  // Handle the tongue retraction logic
        }
    }

    private void HandleTongueExtension()
    {
        if (tongueAnimator)  // Ensure Animator reference is not null
        {
            tongueAnimator.SetBool("isFiring", true);  // Play tongue extension animation
        }

        tongueEnd = transform.position + transform.right * tongueLength;  // Calculate tongue's end position

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, interactableLayers);  // Cast a ray to check for interactions
        if (hit.collider != null)  // Check if ray hit any collider
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable is FlyPowerUp) // Check if interactable object is FlyPowerUp
            {
                ((FlyPowerUp)interactable).frog = this.frogMovement; // Now using the interface
            }

            if (interactable != null)  // Ensure hit object has an Interactable component
            {
                interactable.Interact();  // Trigger interaction
            }
        }
    }

    private void HandleTongueRetraction()
    {
        if (tongueAnimator)  // Ensure Animator reference is not null
        {
            tongueAnimator.SetTrigger("RetractTongue");  // Play tongue retraction animation
        }
    }
}