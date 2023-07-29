using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float boundary = 50.0f;

        // Update is called once per frame
    void Update()
    {
        DestroyAtBoundary();
    }

    //Abstraction
    //If game object reaches this bound, destroy the object.
    void DestroyAtBoundary()
    {
        if (transform.position.x > boundary | transform.position.x < -boundary | transform.position.z < -boundary | transform.position.z > boundary)
        {
            Destroy(gameObject);
        }
    }
}
