using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(100)]

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 25, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
