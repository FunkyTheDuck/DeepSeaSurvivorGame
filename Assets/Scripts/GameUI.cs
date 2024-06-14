using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    private void Start()
    {
        healthBar.value = healthBar.maxValue;
    }
    public void SetMaxHealth(float addedMaxValue)
    {
        healthBar.maxValue = addedMaxValue;
    }
    public void GainHealth(float amount)
    {
        healthBar.value += amount; 
    }
    public void LoseHealth(float amount)
    {
        healthBar.value -= amount;
    }
    public void ChangeHealthBar(bool gainHealth, float amount)
    {
        if(gainHealth)
        {
            healthBar.value -= amount;
        }
        else
        {
            healthBar.value += amount;
        }
    }
}