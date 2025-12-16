using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    LevelManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static int level;

    public UnityEvent OnMelodyEnded;

    private void Awake()
    {

        LevelStartCinemathic();
    }

    public void LevelStartCinemathic()
    {
        //Sunum coroutine!
        LevelStart();
    }
    public void LevelStart()
    {
        MelodyManager.instance.ChangeMelodyList(level);
        level++;
        MelodyManager.instance.StartMelody();
    }
    public void LevelEndCinemathic()
    {
        MelodyManager.instance.StopMelody();
        //Sunum coroutine!
        LevelEnd();
    }
    public void LevelEnd()
    {
        OnMelodyEnded.Invoke();
        if (level == SceneManager.sceneCount+1)
        {
            Debug.Log("Oyun Bitti");
            return;
        }
        //LevelStartCinemathic();
    }











    private IEnumerator Cinemathic(GameObject gameObject, float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

}
