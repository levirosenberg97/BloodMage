using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStats : MonoBehaviour
{
    public bool selectable;
    public int health;

    public Slider healthSlider;

    public PlayerStats stats;

    private void Start()
    {
        health = stats.maxHealth;

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
