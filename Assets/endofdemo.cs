using UnityEngine;

public class endofdemo : MonoBehaviour
{
    [SerializeField] GameObject Obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Obj.SetActive(true);
    }
}
