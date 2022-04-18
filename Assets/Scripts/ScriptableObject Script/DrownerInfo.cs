using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Datos Drowner", menuName = "ScriptableObjects/Drowner", order = 3)]
public class DrownerInfo :  ScriptableObject
{
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;

}
