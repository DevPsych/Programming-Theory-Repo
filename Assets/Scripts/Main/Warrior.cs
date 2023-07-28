using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    [SerializeField] GameObject attackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Move();
    }

    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(attackPrefab, transform.position, attackPrefab.transform.rotation);
        }
    }
}
