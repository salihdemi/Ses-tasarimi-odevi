using UnityEngine;

public class Instrumentalist : MonoBehaviour
{

    public Collider2D col;
    public void Interest()
    {

    }
    public void Leave()
    {
        Debug.Log("leave");
        LevelManager.instance.melodyManager.StopMelody();
        col.isTrigger = true;
    }
}
