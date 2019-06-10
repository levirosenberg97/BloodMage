using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    int maxHealth;

    public int health;
    public Slider healthSlider;

    public int strength;
    public int defense;
    public int spellPower;
    public int speed;

    public EnemyStats target;

    private void Start()
    {
        maxHealth = health;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }
}