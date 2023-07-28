using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
