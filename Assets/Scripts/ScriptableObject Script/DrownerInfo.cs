using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Datos Drowner", menuName = "ScriptableObjects/Drowner", order = 3)]
public class DrownerInfo :  ScriptableObject
{
    public int maxHealth;
    public int currentHealth;
    public int attackDamage;

}
