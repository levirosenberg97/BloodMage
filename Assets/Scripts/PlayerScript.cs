using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public PlayerStats playerStats;
    public Slider healthSlider;
    public int health;


    private void Start()
    {
        health = playerStats.maxHealth;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        gameObject.SetActive(false);
    }
}
