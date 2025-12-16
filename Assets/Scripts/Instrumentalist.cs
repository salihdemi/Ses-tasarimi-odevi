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
        MelodyManager.instance.StopMelody();
        col.isTrigger = true;
    }
}
