using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 7.0f;
    private GameObject player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Hero");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * speed * Time.deltaTime);
    }
}
