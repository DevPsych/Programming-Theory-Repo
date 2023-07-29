using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float bound = 39.0f;
    [SerializeField] int health;
    protected GameManager gameManager;

    // Start is called before the first frame update
    protected void Start()
    {
        health = 3;
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }

    protected void Update()
    {
        if (gameManager.isGameActive)
        {
            Attack();
            //Inherited from the Hero class
            Move();
        }
    }

    //Inheritance
    //All children of this class takes player's input to move
    protected void Move()
    {
        SetPlayerBoundary();

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    //The player cannot move beyond boundary
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

    //All children require an attack method
    protected abstract void Attack();

    //Player loses health when they collide with enemy
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
