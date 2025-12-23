using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public float maxFallSpeed = 20f; // Maksimum düþüþ hýzý
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Eðer y eksenindeki hýz, negatif yönde (aþaðý doðru) limiti aþarsa
        if (rb.linearVelocity.y < -maxFallSpeed)
        {
            // Hýzý limit deðerine sabitle
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -maxFallSpeed);
        }
    }
}