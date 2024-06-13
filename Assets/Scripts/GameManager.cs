using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player PlayerScript;
    public SkillManager SkillManager;
    public EnemieManager EnemieManager;

    void Start()
    {
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
        SkillManager = GameObject.Find("Player").GetComponent<SkillManager>();
        EnemieManager = gameObject.GetComponent<EnemieManager>();


        StartWeapons();
    }
    public void PlayerLeveledUp()
    {
        Debug.Log("Player level up");
        Time.timeScale = 0f;
    }
    private void StartWeapons()
    {
        Task.Delay(100);
        SkillManager.StartWeapons(this);
    }
    public Vector3 GetPlayerPos()
    {
        return PlayerScript.transform.position;
    }
}