using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melody", menuName = "ScriptableObjects/Melody")]
public class Melody : ScriptableObject
{
    public AudioClip[] clips;
    public string[] codes;
}
