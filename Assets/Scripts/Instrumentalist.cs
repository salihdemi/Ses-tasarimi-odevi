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
        GetComponent<SpriteRenderer>().color = Color.grey;
        col.isTrigger = true;
    }
}
