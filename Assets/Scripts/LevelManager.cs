using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        LevelStartCinemathic();
    }

    public void LevelStartCinemathic()
    {
        LevelStart();
    }
    public void LevelStart()
    {
        MelodyManager.instance.ChangeMelodyList(level);
        MelodyManager.instance.StartMelody();
    }
    public void LevelEndCinemathic()
    {
        MelodyManager.instance.StopMelody();
        LevelEnd();
    }
    public void LevelEnd()
    {
        if (level == SceneManager.sceneCount)
        {
            Debug.Log("Oyun Bitti");
            return;
        }
        NextLevel();
        LevelStartCinemathic();
    }
    public static void NextLevel()
    {
        level++;
        SceneManager.LoadScene(level);
    }











    private IEnumerator Cinemathic(GameObject gameObject, float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

}
