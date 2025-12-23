using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransiction : MonoBehaviour
{
    public int sceneToLoad;
    public int time;

    public ControllerDisabler disabler;
    private void Transiction()
    {
        //LevelManager.instance.LevelStartCinemathic();
        StartCoroutine(Wait(time));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(disabler != null)
        {
            disabler.Disable();
        }
        Transiction();
    }

    IEnumerator Wait(int x)
    {
        // 5 saniye bekle
        yield return new WaitForSeconds(x);

        SceneManager.LoadScene(sceneToLoad);
    }
}
