using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float boundary = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > boundary | transform.position.x < -boundary | transform.position.z < -boundary | transform.position.z > boundary)
        {
            Destroy(gameObject);
        }
    }
}
