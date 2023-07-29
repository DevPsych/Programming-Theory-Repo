using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    [SerializeField] GameObject attackPrefab;
    [SerializeField] float cooldownTime = 0.6f;
    private bool canUse = true;

    //Polymorphism
    //Warrior has own unique attack
    protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUse)
        {
            canUse = false;
            Instantiate(attackPrefab, transform.position, attackPrefab.transform.rotation);
            StartCoroutine(SkillCooldown(cooldownTime));
        }
    }

    //Cooldown before warrior can use skill again
    IEnumerator SkillCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }
}
