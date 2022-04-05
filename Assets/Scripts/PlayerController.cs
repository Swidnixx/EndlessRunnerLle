using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    Rigidbody2D rb;
    Collider2D boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        DebugDraw();

        if(Input.GetMouseButtonDown(0))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(0, jumpPower); 
            }
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.bounds.size,
            0,
            Vector2.down,
            0.1f,
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }

    void DebugDraw()
    {
        Vector3 playerPos = transform.position;
        Debug.DrawLine(playerPos, playerPos + Vector3.down * 1.1f);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 playerPos = transform.position;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(playerPos, transform.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerPos + Vector3.down * 0.1f, transform.localScale);
    }
}
