using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateTrigger : MonoBehaviour
{
    public Transform doorTransform;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = doorTransform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            Vector3 newPosition = initialPosition + new Vector3(0f, 2f, 0f);
            doorTransform.position = newPosition;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            doorTransform.position = initialPosition;
        }
    }
}
