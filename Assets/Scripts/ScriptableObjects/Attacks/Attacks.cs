using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Attacks", order = 1)]
public class Attacks : ScriptableObject
{
    public int attackPower;

    public bool isMagic;
    public bool isPhysical;
}
