using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetObject : MonoBehaviour
{
    public PlayerStats stats;

    public int newHealth;
    public int health;
    public Slider healthSlider;
    public int defending = 1;

    public TargetObject target;

    private void Start()
    {
        health = stats.maxHealth;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
}
