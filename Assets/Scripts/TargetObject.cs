﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetObject : MonoBehaviour
{
    public PlayerStats stats;

    public int health;
    public Slider healthSlider;

    public GameObject target;

    private void Start()
    {
        health = stats.maxHealth;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
}
