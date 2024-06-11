using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<SkillBase> SkillList;
    public Player PlayerScript;
    public SkillManager SkillManager;
    public EnemieManager EnemieManager;

    void Start()
    {
        SkillList = new List<SkillBase>
        {
            new SkillBase
            {
                Id = 0,
                Name = "Torpedo",
                Level = 1,
                Description = "Fires a torpedo at the facing direction every x seconds",
                Damage = 50,
                Cooldown = 3,
                TimeToDestory = 3,
                Radius = 10,
                Speed = 1000,
            }
        };
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
        SkillManager = GameObject.Find("Player").GetComponent<SkillManager>();
        EnemieManager = gameObject.GetComponent<EnemieManager>();


        StartWeapons();
    }
    private void  StartWeapons()
    {
        SkillManager.StartTorpedo();
    }



    public SkillBase GetSkillBaseFromName(string name)
    {
        return SkillList.FirstOrDefault(s => s.Name == name);
    }
}