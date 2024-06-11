using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public string Name;
    public EnemieManager EnemieManager;
    public EnemieBase Stats;
    void Start()
    {
        EnemieManager = GameObject.Find("GameManager").GetComponent<EnemieManager>();
        Stats = EnemieManager.GetEnemieBaseFromName(Name);
    }
}