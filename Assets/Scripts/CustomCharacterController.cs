using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public enum State { Normal, Sliding }
public class CustomCharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8;
    public float jumpingPower = 10;
    public float gravityScale = 3;

    //private
    private float horizontal;
    private bool isGrounded;

    #region Classlar
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    #endregion



    #region Sistem Fonksiyonlarý
    private void Awake()
    {
        InitializeComponents();
        ChangeGravityActive(true);
    }
    void Update()
    {
        CheckJump();
        Turn();
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                CollideGround();
                break;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                UnCollideGround();
                break;

            case "Wall":
                //Sekme hakkini azalt
                break;
        }
    }
    #endregion

    #region Temel Kontrol fonksiyonlarý
    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (true)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
    }
    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            //JumpAnimation
        }
        else if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            //FallingAnimation
        }
    }
    private void Turn()
    {
        bool x = spriteRenderer.flipX;
        if ((!x && horizontal < 0f || x && horizontal > 0f))
        {
            x = !x;
        }
        spriteRenderer.flipX = x;
    }
    #endregion

    #region Diðer fonksiyonlar
    private void InitializeComponents()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void CollideGround()
    {
        isGrounded = true;
    }
    private void UnCollideGround()
    {
        isGrounded = false;
    }
    public void ChangeGravityActive(bool isActive)
    {
        if (isActive)
            rb.gravityScale = gravityScale;
        else
            rb.gravityScale = 0f;
    }
    #endregion

}