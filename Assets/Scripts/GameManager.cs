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
    public GameUI GameUIScript;

    void Start()
    {
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
        SkillManager = GameObject.Find("Player").GetComponent<SkillManager>();
        GameUIScript = GameObject.Find("GameUI").GetComponent<GameUI>();
        EnemieManager = gameObject.GetComponent<EnemieManager>();

        GameUIScript.SetMaxHealth(PlayerScript.GetMaxHealth());
        StartWeapons();
    }
    public void PlayerLeveledUp(float currentHealth, float maxHealth)
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