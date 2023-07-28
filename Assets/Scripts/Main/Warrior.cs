using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    [SerializeField] GameObject attackPrefab;
    [SerializeField] float cooldownTime = 0.6f;
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
            Instantiate(attackPrefab, transform.position, attackPrefab.transform.rotation);
            StartCoroutine(SkillCooldown(cooldownTime));
        }
    }

    IEnumerator SkillCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }
}
