using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public MelodyManager melodyManager;

    public UnityEvent OnMelodyEnded;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        Debug.Log(instance);
        LevelStartCinemathic();
    }

    public void LevelStartCinemathic()
    {
        //Sunum coroutine!
        LevelStart();
    }
    public void LevelStart()
    {
        melodyManager.StartMelody();
    }
    public void LevelEndCinemathic()
    {
        LevelManager.instance.melodyManager.StopMelody();
        //Sunum coroutine!
        LevelEnd();
    }
    public void LevelEnd()
    {
        OnMelodyEnded.Invoke();
        Debug.Log(SceneManager.loadedSceneCount + " " + SceneManager.sceneCountInBuildSettings);
        if (SceneManager.loadedSceneCount == SceneManager.sceneCountInBuildSettings)
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
