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

    [Header("Hit Area")]
    public Vector3 point;
    public Vector2 hitAreaSize;
    public LayerMask hitableLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Hit();
        }
    }

    private void Hit()
    {
        //Aþaðý fýrlama 
        col.sharedMaterial = bouncy;

        rb.AddForce(Vector3.down * 10, ForceMode2D.Impulse);


        //overlap
        Collider2D bell = Physics2D.OverlapBox(transform.position + point, hitAreaSize, 0, hitableLayers);



        //Animasyon
        animator.SetTrigger("Hit");



        //Ses
        if (bell)
        {
            bell.GetComponent<Bell>().Ring();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        col.sharedMaterial = bounceless;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector2 center = transform.position + point;

        Gizmos.DrawWireCube(center, hitAreaSize);
    }

}
