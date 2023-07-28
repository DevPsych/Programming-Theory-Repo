using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 360.0f;
    private GameObject player;
    private ActiveSkillTime activeSkillTimeScript;
    [SerializeField] float activeSkillTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Hero");
        activeSkillTimeScript = GameObject.FindWithTag("Skill").GetComponent<ActiveSkillTime>();
    }

    // Update is called once per frame
    void Update()
    {
        SpinSword();
    }

    void SpinSword()
    {
        float angle = -rotationSpeed * Time.deltaTime;
        transform.RotateAround(player.transform.position, Vector3.up, angle);
        transform.position = player.transform.position;
        StartCoroutine(activeSkillTimeScript.SkillTime(activeSkillTime));
    }
}
