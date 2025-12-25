using UnityEngine;

public enum State { Normal, Sliding }

public class CustomCharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8;
    public float jumpingPower = 10;
    public float gravityScale = 3;

    private float horizontal;
    private bool isGrounded;
    private bool isFalling;

    #region Classlar
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    #endregion

    private void Awake()
    {
        InitializeComponents();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        // Önce hareket girdisini alalım ama animasyonu hemen oynatmayalım
        horizontal = Input.GetAxisRaw("Horizontal");

        CheckJump();
        Turn();
        MoveLogic();
        UpdateAnimations(); // Animasyonları tek bir yerden yönetmek en sağlıklısıdır
    }

    private void MoveLogic()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void CheckJump()
    {
        // Zıplama Başlatma
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);

            // Zıplama anında diğer her şeyi susturalım
            animator.SetBool("Ground", false);
            animator.SetTrigger("Jump");

            isGrounded = false; // Çakışmayı önlemek için hemen false yapıyoruz
            isFalling = false;
        }

        // Havada olma durumu
        if (!isGrounded)
        {
            // Düşüş kontrolü
            if (rb.linearVelocity.y < -0.1f && !isFalling)
            {
                animator.SetTrigger("Fall");
                isFalling = true;
            }

            // Yarım zıplama kontrolü
            if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocity.y > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }
    }

    private void UpdateAnimations()
    {
        // Sadece yerdeyken Moving animasyonuna izin ver
        if (isGrounded)
        {
            animator.SetBool("Moving", horizontal != 0);
        }
        else
        {
            // Havadayken Moving bool'u kapalı olmalı ki Jump/Fall animasyonu kesilmesin
            animator.SetBool("Moving", false);
        }
    }

    private void Turn()
    {
        if (horizontal > 0) spriteRenderer.flipX = false;
        else if (horizontal < 0) spriteRenderer.flipX = true;
    }

    #region Çarpışma Kontrolleri
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isFalling = false;
            animator.SetBool("Ground", true);
            animator.ResetTrigger("Jump"); // Kalan triggerları temizle
            animator.ResetTrigger("Fall");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Ground", false);
        }
    }
    #endregion

    private void InitializeComponents()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }
}