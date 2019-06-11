using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    PlayerStats playerStats;
    public Slider healthSlider;
    int maxHealth;


    private void Start()
    {
        maxHealth = playerStats.health;
        healthSlider.maxValue = playerStats.health;
        healthSlider.value = playerStats.health;
    }
}
