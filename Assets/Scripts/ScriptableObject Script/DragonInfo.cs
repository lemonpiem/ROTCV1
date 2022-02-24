using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dragon Stats", menuName = "ScriptableObjects/Dragons", order = 2)]
public class DragonInfo : ScriptableObject
{
    public string dragonType;
    public int damage;
    public int health;
    public Material skin;
}
