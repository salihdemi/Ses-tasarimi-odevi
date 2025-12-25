using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MelodyManager : MonoBehaviour
{
    


    

    public List<string> currentMelodyStrings = new List<string>();

    public string[] neededMelody;


    [SerializeField] private AudioSource audioSource;
    private AudioClip[] audioClips;


    public MelodyList melodyList;
    public int melodyNumber;


    private Coroutine playingMelodyCoroutine;


    public void StartMelody()
    {
        ChangeMelody(melodyList.melodies[melodyNumber]);
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
        //melodyNumber++;
        audioClips = melody.clips;
        neededMelody = melody.codes;
        //Debug.Log(melody);
    }
    public void CheckMelody(string melodyCode)
    {
        // 1. Notayý temizle ve ekle
        currentMelodyStrings.Add(melodyCode.Trim());

        // 2. Kayan pencere: Listenin boyutu hedef melodiden uzunsa en eskiyi sil
        if (currentMelodyStrings.Count > neededMelody.Length)
        {
            currentMelodyStrings.RemoveAt(0);
        }

        // 3. Boyutlar eþitse kontrol et
        if (currentMelodyStrings.Count == neededMelody.Length)
        {
            // Büyük-küçük harf duyarsýz ve boþluksuz karþýlaþtýrma
            bool esitMi = currentMelodyStrings.SequenceEqual(neededMelody.Select(s => s.Trim()), System.StringComparer.OrdinalIgnoreCase);

            if (esitMi)
            {
                // Debug: Durumu anlamak için konsola yazdýr
                Debug.Log($"Doðru! Mevcut Ýndis: {melodyNumber}, Toplam Melodi: {melodyList.melodies.Length}");

                // 4. SON MELODÝ KONTROLÜ
                // Ýndis 0'dan baþladýðý için (Toplam - 1) sonuncudur.
                if (melodyNumber >= melodyList.melodies.Length - 1)
                {
                    Debug.Log("3 - TÜM MELODÝLER BÝTTÝ!");
                    LevelManager.instance.LevelEndCinemathic();
                }
                else
                {
                    Debug.Log("3 - Sonraki melodiye geçiliyor...");

                    // Ýndisi burada artýrýyoruz
                    melodyNumber++;

                    // Yeni melodiyi yükle
                    ChangeMelody(melodyList.melodies[melodyNumber]);
                }

                // Yeni melodiye geçildiði için oyuncunun yazdýðý listeyi sýfýrla
                currentMelodyStrings.Clear();
            }
        }
    }

    /*

    public void CheckMelody(string melodyCode)
    {
        currentMelodyStrings.Add(melodyCode);


        Debug.Log("-1");

        if (currentMelodyStrings.Count == neededMelody.Length+1)
        {
            Debug.Log("-0");
            if (currentMelodyStrings.SequenceEqual(neededMelody))
            {
                Debug.Log("-0.5");
                string[] lastMelody = melodyList.melodies[melodyList.melodies.Length - 1].codes;

                if (currentMelodyStrings.SequenceEqual(lastMelody))//Son melodiyse
                {
                    Debug.Log("1");
                    LevelManager.instance.LevelEndCinemathic();//Bölüm bitimi ve diðer bölüme geçme
                }
                else
                {
                    Debug.Log("2");
                    // Þaþýrma animasyonu
                    // bekleme
                    // karakteri izleyerek çalma animasyonu
                    Debug.Log("changemelody");
                    ChangeMelody(melodyList.melodies[melodyNumber]);//Sonraki melodiye geç
                }

            }



            currentMelodyStrings.RemoveAt(0);
        }
    }
    */


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
                yield return new WaitForSeconds(clip.length);
            }
            yield return new WaitForSeconds(0);
        }
    }
}









//çok paramýz olunca vakumlu kaplama makinasý alacaðýz