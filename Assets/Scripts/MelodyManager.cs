using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class MelodyManager : MonoBehaviour
{
    


    

    public List<string> currentMelodyStrings = new List<string>();

    public string[] neededMelody;

    private MelodyList melodyList;

    [SerializeField] private AudioSource audioSource;
    private AudioClip[] audioClips;


    public MelodyList currentMelodyList;
    public int melodyNumber;


    private Coroutine playingMelodyCoroutine;


    public void StartMelody()
    {
        Debug.Log(currentMelodyList.melodies);
        ChangeMelody(currentMelodyList.melodies[melodyNumber]);
        if (playingMelodyCoroutine == null)
        {
            playingMelodyCoroutine = StartCoroutine(PlayAudioSequence());
        }
    }
    public void StopMelody()
    {
        StopCoroutine(playingMelodyCoroutine);
    }

    public void ChangeMelody(Melody melody)
    {
        melodyNumber++;
        audioClips = melody.clips;
        neededMelody = melody.codes;
        Debug.Log(melody);
    }



    public void CheckMelody(string melodyCode)
    {
        currentMelodyStrings.Add(melodyCode);



        if (currentMelodyStrings.Count == neededMelody.Length)
        {
            if (currentMelodyStrings.SequenceEqual(neededMelody))
            {
                string[] lastMelody = currentMelodyList.melodies[currentMelodyList.melodies.Length - 1].codes;

                if (currentMelodyStrings.SequenceEqual(lastMelody))//Son melodiyse
                {
                    LevelManager.instance.LevelEndCinemathic();//Bölüm bitimi ve diðer bölüme geçme
                }
                else
                {
                    // Þaþýrma animasyonu
                    // bekleme
                    // karakteri izleyerek çalma animasyonu
                    ChangeMelody(currentMelodyList.melodies[melodyNumber]);//Sonraki melodiye geç
                }

            }



            currentMelodyStrings.RemoveAt(0);
        }
    }



    private IEnumerator PlayAudioSequence()
    {
        while (true)
        {
            foreach (AudioClip clip in audioClips)
            {
                if (clip == null) continue;
                audioSource.clip = clip;
                audioSource.Play();
                // Audio bitene kadar bekle
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1);
        }
    }
}









//çok paramýz olunca vakumlu kaplama makinasý alacaðýz