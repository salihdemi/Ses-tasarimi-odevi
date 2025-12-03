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

    public List<Melody> levelMelodies = new List<Melody>();

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

    public void ChangeMelody(Melody sounds)
    {
        audioClips = sounds.clips;
        neededMelody = sounds.codes;
    }



    public static void AddMelody(string melodyCode)
    {
        currentMelody.Add(melodyCode);



        if (currentMelody.Count == neededMelody.Length)
        {
            if (currentMelody.SequenceEqual(neededMelody))
            {
                LevelManager.instance.LevelEndCinemathic();
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
                yield return new WaitForSeconds(1);
            }
        }
    }
}









//çok paramýz olunca vakumlu kaplama makinasý alacaðýz