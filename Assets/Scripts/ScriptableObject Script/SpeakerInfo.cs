using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Speaker", menuName ="Data/New Speaker")]
public class SpeakerInfo : ScriptableObject
{
    public string speakerName;
    public Color textColor;
    public Sprite speakerImage;
    
}
