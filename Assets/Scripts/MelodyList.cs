using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MelodyList", menuName = "ScriptableObjects/MelodyList")]
public class MelodyList : ScriptableObject
{
    public Melody[] melodies;
}
