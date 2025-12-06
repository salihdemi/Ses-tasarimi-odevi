using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static Cinemachine.DocumentationSortingAttribute;

public class MelodyManager : MonoBehaviour
{
    
    public static MelodyManager instance;
    MelodyManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public static List<string> currentMelody = new List<string>();

    public static string[] neededMelody;



    [SerializeField] private AudioSource audioSource;
    private AudioClip[] audioClips;


    public List<MelodyList> levelMelodyLists = new List<MelodyList>();
    public static MelodyList currentMelodyList;
    public static int melodyNumber;


    private Coroutine playingMelodyCoroutine;



    public static int level=0;


    public UnityEvent levelEndEvent;
    private void Awake()
    {
        ChangeMelodyList(level);
        instance.StartMelody();
        //DontDestroyOnLoad(gameObject);
    }

    public void StartMelody()
    {
        playingMelodyCoroutine = StartCoroutine(PlayAudioSequence());
    }
    public void StopMelody()
    {
        StopCoroutine(playingMelodyCoroutine);
    }

    public void ChangeMelodyList(int level)
    {
        currentMelodyList = levelMelodyLists[level];
        melodyNumber = 0;
        ChangeMelody(currentMelodyList.melodies[melodyNumber]);

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
        currentMelody.Add(melodyCode);


        Debug.Log(currentMelody);
        Debug.Log(neededMelody);
        if (currentMelody.Count == neededMelody.Length)
        {
            if (currentMelody.SequenceEqual(neededMelody))
            {
                string[] lastMelody = currentMelodyList.melodies[currentMelodyList.melodies.Length - 1].codes;

                if (currentMelody.SequenceEqual(lastMelody))//Son melodiyse
                {
                    StopMelody();
                    levelEndEvent.Invoke();
                    //LevelManager.instance.LevelEndCinemathic();//Bölüm bitimi ve diðer bölüme geçme
                }
                else
                {
                    // Þaþýrma animasyonu
                    // bekleme
                    // karakteri izleyerek çalma animasyonu
                    ChangeMelody(currentMelodyList.melodies[melodyNumber]);//Sonraki melodiye geç
                }

            }



            currentMelody.RemoveAt(0);
        }
    }



    IEnumerator PlayAudioSequence()
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