using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueMovement_2 : MonoBehaviour
{
    public float tongueLength = 3f;  // Maximum length the tongue can extend
    public float interactionDistance = 2f;  // Distance within which tongue can interact with objects
    public LayerMask interactableLayers;  // Layers that tongue can interact with
    private Animator tongueAnimator;  // Reference to the Animator component
    public FrogMovement2 frogMovement; 
    private Vector2 tongueEnd;  // Calculated end point of the tongue

    void Start()
    {
        // Initialize the tongueAnimator reference
        tongueAnimator = GetComponent<Animator>();  // Fetch the Animator component on this GameObject
        if (!tongueAnimator)  // Check if Animator component is present
        {
            Debug.LogError("No Animator component found on this GameObject!", this);  // Log error if Animator is missing
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))  // Check for T key press (specific for second frog)
        {
            HandleTongueExtension();  // Handle the tongue extension logic
        }
        else if (Input.GetKeyUp(KeyCode.T))  // Check for T key release (specific for second frog)
        {
            HandleTongueRetraction();  // Handle the tongue retraction logic
        }
    }

    private void HandleTongueExtension()
    {
        if (tongueAnimator)  // Ensure Animator reference is not null
        {
            tongueAnimator.SetTrigger("ExtendTongue");  // Play tongue extension animation
        }

        tongueEnd = transform.position + transform.right * tongueLength;  // Calculate tongue's end position

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, interactableLayers);  // Cast a ray to check for interactions
        

        if (hit.collider != null)  // Check if ray hit any collider
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();  // Fetch the Interactable component of hit object
            if (interactable is FlyPowerUp) // Check if interactable object is FlyPowerUp
            {
                ((FlyPowerUp)interactable).frog = this.frogMovement; // Use the updated field name and type
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
