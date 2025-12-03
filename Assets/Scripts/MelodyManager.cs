using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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



        if (currentMelody.Count == neededMelody.Length)
        {
            if (currentMelody.SequenceEqual(neededMelody))
            {
                string[] lastMelody = currentMelodyList.melodies[currentMelodyList.melodies.Length - 1].codes;

                if (currentMelody.SequenceEqual(lastMelody))
                {
                    Debug.Log("Bölüm geç");
                    //sonraki bölüme geç
                    LevelManager.instance.LevelEndCinemathic();
                }
                else
                {
                    Debug.Log("Melodi geç");
                    // sonraki melodiye geç
                    ChangeMelody(currentMelodyList.melodies[melodyNumber]);
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