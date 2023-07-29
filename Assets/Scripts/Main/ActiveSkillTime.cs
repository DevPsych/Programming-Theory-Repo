using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillTime : MonoBehaviour
{
    //Duration of skill before destruction
    //It may be good to create a skill class and implement inheritance
    public IEnumerator SkillTime(float activeSkillTime)
    {
        yield return new WaitForSeconds(activeSkillTime);
        Destroy(gameObject);
    }
}
