using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(100)]

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 25, 0);
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
            MoveCamera();
        }
    }

    //Abstraction
    //Moves camera along with the player
    void MoveCamera()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
