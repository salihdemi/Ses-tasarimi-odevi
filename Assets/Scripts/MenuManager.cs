using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject a;
    public void Basla()
    {
        SceneManager.LoadScene(1);
    }
    public void Nasil()
    {
        a.SetActive(true);
    }
    public void Cik()
    {
        Application.Quit();
    }
}
