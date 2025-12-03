using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHit : MonoBehaviour
{
    [Header("Classes")]
    public Animator animator;
    public Rigidbody2D rb;
    public Collider2D col;


    [Header("Physics Materials")]
    public PhysicsMaterial2D bounceless;
    public PhysicsMaterial2D bouncy;

    [Header("Hit")]
    public LayerMask hitableLayers;


    private bool hitting;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit();
        }
    }

    private void Hit()
    {
        hitting = true;
        //Aþaðý fýrlama 
        col.sharedMaterial = bouncy;

        rb.AddForce(Vector3.down * 10, ForceMode2D.Impulse);


        //overlap
        //Collider2D bell = Physics2D.OverlapBox(transform.position + point, hitAreaSize, 0, hitableLayers);



        //Animasyon
        animator.SetTrigger("Hit");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitting)
        {
            hitting = false;
            {
                if(((1 << collision.gameObject.layer) & hitableLayers) != 0)//layer kontrolü
                {
                    //Ses
                    collision.gameObject.GetComponent<Bell>().Ring();
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        col.sharedMaterial = bounceless;
    }

}
