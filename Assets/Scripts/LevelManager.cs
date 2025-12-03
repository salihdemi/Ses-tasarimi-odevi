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


    public static int finalLevel = 1;

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
        MelodyManager.instance.ChangeMelody(MelodyManager.instance.levelMelodies[level]);
        MelodyManager.instance.StartMelody();
    }
    public void LevelEndCinemathic()
    {
        MelodyManager.instance.StopMelody();
        LevelEnd();
    }
    public void LevelEnd()
    {
        NextLevel();
        LevelStartCinemathic();
    }
    public static void NextLevel()
    {
        if (level == finalLevel)
        {
            Debug.Log("Oyun Bitti");
            return;
        }
        level++;
        SceneManager.LoadScene(level);
    }











    private IEnumerator Cinemathic(GameObject gameObject, float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

}
