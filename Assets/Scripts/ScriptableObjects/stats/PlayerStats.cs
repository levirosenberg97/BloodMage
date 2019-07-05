using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Stats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int maxHealth;
    
    public int strength;
    public int defense;
    public int spellPower;
    public int speed;

    public Attacks currentAttack;

    public enum PlayerType { Player, MagicEnemy, PhysicalEnemy};
    public PlayerType type;

    public Attacks physicalAttack;
    public Attacks magicAttack;
}