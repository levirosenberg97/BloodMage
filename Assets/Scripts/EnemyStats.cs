using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyStats : MonoBehaviour
{
    public bool selectable;
    int maxHealth;

    public Slider healthSlider;

    PlayerStats stats;

    private void Start()
    {
        maxHealth = stats.health;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = stats.health;
    }

    public void Test()
    {
        Debug.Log("Hit");
    }

}
