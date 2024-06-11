using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemieBase
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public string Description { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
}