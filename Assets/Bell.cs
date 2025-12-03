using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public string melodyCode;
    public AudioSource audioSource;
    public void Ring()
    {
        audioSource.Play();
        MelodyManager.AddMelody(melodyCode);
    }
}
