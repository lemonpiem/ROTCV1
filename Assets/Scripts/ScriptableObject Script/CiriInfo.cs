using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Datos Player", menuName = "ScriptableObjects/Cirilla", order = 1)]
public class CiriInfo : ScriptableObject
{
    public string playername;
    public float speed;
    public float jumpForce;
    public Material material;
    public float life;
}
