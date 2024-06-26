using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    GameManager myGM;
    public List<SkillBase> SkillList;
    Transform torpedoPos;
    public GameObject TorpedoPrefab;
    SkillBase torpedoStats;
    private void Start()
    {
        CreateSkillList();
    }
    private void CreateSkillList()
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
                Speed = 400,
                IsActive = true,
            }
        };
    }
    public void StartWeapons(GameManager myGm)
    {
        if(SkillList != null)
        {
            CreateSkillList();
        }
        myGM = myGm;
        Debug.Log(SkillList[0].Name);
        foreach (SkillBase weapon in SkillList)
        {
            if(weapon.IsActive)
            {
                switch (weapon.Name.ToLower())
                {
                    case "torpedo":
                        StartTorpedo();
                        break;
                    case "":
                        break;

                }
            }
        }
    }
    private void StartTorpedo()
    {
        Debug.Log("Start firing torpedos");
        torpedoStats = GetSkillBaseFromName("Torpedo");
        torpedoPos = transform.GetChild(1).transform.GetChild(1).transform;
        CreateTorpedo();
    }
    public SkillBase GetSkillBaseFromName(string name)
    {
        return SkillList.FirstOrDefault(s => s.Name == name);
    }
    private IEnumerator ReloadTorpedo(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CreateTorpedo();
    }
    private void CreateTorpedo()
    {
        GameObject torpedo = Instantiate(TorpedoPrefab);
        torpedo.transform.position = torpedoPos.position;
        torpedo.GetComponent<Torpedo>().skill = torpedoStats;
        if (transform.GetChild(1).transform.rotation.y > 0)
        {
            torpedo.GetComponent<Torpedo>().facingRight = false;
        }
        else
        {
            torpedo.GetComponent<Torpedo>().facingRight = true;
        }
        StartCoroutine(ReloadTorpedo(3));
    }
}