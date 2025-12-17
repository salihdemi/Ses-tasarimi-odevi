using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransiction : MonoBehaviour
{
    public int sceneToLoad;
    private void Transiction()
    {
        //LevelManager.instance.LevelStartCinemathic();
        SceneManager.LoadScene(sceneToLoad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transiction();
    }
}
