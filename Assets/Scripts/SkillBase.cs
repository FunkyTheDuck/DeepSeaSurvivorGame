using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public string Description { get; set; }
    public float Damage { get; set; }
    public float Cooldown { get; set; }
    public float TimeToDestory { get; set;}
    public float Radius { get; set; }
    public float Speed { get; set; }
    public bool IsActive { get; set; }
}