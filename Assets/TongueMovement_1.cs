using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueMovement_1 : MonoBehaviour
{
    public float tongueLength = 3f;
    public float interactionDistance = 2f;
    public LayerMask interactableLayers;
    
    private LineRenderer lineRenderer;
    private Vector2 tongueEnd;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            lineRenderer.enabled = true;
            tongueEnd = transform.position + transform.right * tongueLength;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, tongueEnd);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, interactableLayers);
            if (hit.collider != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightControl))
        {
            lineRenderer.enabled = false;
        }
    }
}
