using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public string Name;
    public EnemieManager EnemieManager;
    public EnemieBase Stats;
    private Transform playerPos;
    bool hitPlayer = false;
    void Start()
    {
        EnemieManager = GameObject.Find("GameManager").GetComponent<EnemieManager>();
        Stats = EnemieManager.GetEnemieBaseFromName(Name);
        playerPos = GameObject.FindWithTag("Player").transform;

        Debug.Log(Name + " - " + Stats.Health);
    }
    private void Update()
    {
        if(Stats != null)
        {
            if(playerPos != null)
            {
                if (!hitPlayer)
                {
                    Vector3 direction = (playerPos.position - transform.position).normalized;
                    transform.position += direction * Stats.Speed * Time.deltaTime;
                }
                else
                {
                    Vector3 direction = (playerPos.position - transform.position).normalized;
                    transform.position -= direction * Stats.Speed * Time.deltaTime;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            SkillBase skill = collision.gameObject.GetComponent<PlayerWeapon>().GetWeaponStats();
            if (skill != null)
            {
                Stats.Health -= skill.Damage;
            }
            else
            {
                Debug.Log("Weapon doesn't exists");
            }
            if (Stats.Health < 0)
            {
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "Player")
        {
            hitPlayer = true;
            StartCoroutine(ResetHitPlayer());
        }
    }
    private IEnumerator ResetHitPlayer()
    {
        yield return new WaitForSeconds(Stats.RecoverTime);

        hitPlayer = false;
    }
}