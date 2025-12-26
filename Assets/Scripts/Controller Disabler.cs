using UnityEngine;

public class ControllerDisabler : MonoBehaviour
{
    [SerializeField]CustomCharacterController characterController;
    [SerializeField] CharacterHit characterHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Disable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        characterController.enabled = true;
        characterHit.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Disable();
    }
    public void Disable()
    {
        characterController.enabled = false;
        characterHit.enabled = false;
    }
}
