using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    [SerializeField] GameObject attackPrefab;
    [SerializeField] float cooldownTime = 1f;
    private float xOffset = 2.0f;
    private float zOffset = 2.0f;
    private bool canUse = true;

    // Update is called once per frame
    void Update()
    {
        Attack();
        Move();
    }

    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUse)
        {
            canUse = false;
            SpawnBalls();
            StartCoroutine(SkillCooldown(cooldownTime));
        }
    }

    IEnumerator SkillCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }

    void SpawnBalls()
    {
        Instantiate(attackPrefab, transform.position + new Vector3(xOffset, 0, zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 45, 0));
        Instantiate(attackPrefab, transform.position + new Vector3(xOffset, 0, -zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 135, 0));
        Instantiate(attackPrefab, transform.position + new Vector3(-xOffset, 0, -zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 225, 0));
        Instantiate(attackPrefab, transform.position + new Vector3(-xOffset, 0, zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 315, 0));
    }
}
