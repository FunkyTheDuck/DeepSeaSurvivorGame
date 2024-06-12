using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public SkillBase GetWeaponStats()
    {
        SkillBase skillbase = null;
        if(name.ToLower().Contains("torpedo"))
        {
            skillbase = GetComponent<Torpedo>().skill;
        }
        return skillbase;
    }
}