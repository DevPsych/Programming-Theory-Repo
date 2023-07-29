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

    //Polymorphism
    //Mage has own custom attack
    protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUse)
        {
            canUse = false;
            SpawnBalls();
            StartCoroutine(SkillCooldown(cooldownTime));
        }
    }

    //Cooldown before mage can attack again
    IEnumerator SkillCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }

    //Spawn balls for skill around the player
    void SpawnBalls()
    {
        Instantiate(attackPrefab, transform.position + new Vector3(xOffset, 0, zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 45, 0));
        Instantiate(attackPrefab, transform.position + new Vector3(xOffset, 0, -zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 135, 0));
        Instantiate(attackPrefab, transform.position + new Vector3(-xOffset, 0, -zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 225, 0));
        Instantiate(attackPrefab, transform.position + new Vector3(-xOffset, 0, zOffset), attackPrefab.transform.rotation * Quaternion.Euler(0, 315, 0));
    }
}
