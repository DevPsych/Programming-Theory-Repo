using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float bound = 39.0f;
    [SerializeField] int health = 3;
    private GameManager gameManager;

    // Start is called before the first frame update
    protected void Start()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void Move()
    {
        SetPlayerBoundary();

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    void SetPlayerBoundary()
    {
        if (transform.position.x < -bound)
        {
            transform.position = new Vector3(-bound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > bound)
        {
            transform.position = new Vector3(bound, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -bound);
        }

        if (transform.position.z > bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bound);
        }
    }

    public abstract void Attack();

    private void OnTriggerEnter(Collider other)
    {
        health--;
        Destroy(other.gameObject);
        if (health < 1)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
        Debug.Log("You have " + health + " HP remaining.");
    }
}
