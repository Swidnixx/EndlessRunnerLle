using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10;
    public float liftingForce = 10;
    Rigidbody2D rb;
    Collider2D boxCollider;

    bool doubleJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnValidate()
    {
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
                doubleJumped = false;
            }
            else if(!doubleJumped)
            {
                rb.velocity = new Vector2(0, jumpPower);
                doubleJumped = true;
            }
        }
        else if(Input.GetMouseButton(0))
        {
            if(rb.velocity.y < 0)
            {
                rb.AddForce(Vector2.up * liftingForce * rb.velocity.y * -0.5f * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            ObstacleHit();
        }

        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.CoinCollected();
        }

        if(collision.CompareTag("Battery"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.BatteryCollected();
        }

        if (collision.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.MagnetCollected();
        }
    }
    private void ObstacleHit()
    {
        if (!GameManager.Instance.battery.isActive)
        {
            GameManager.Instance.GameOver();
        }
    }
    bool IsGrounded() //Sprawdza czy grzacz stoi na ziemi
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            (Vector2)transform.position + boxCollider.offset,
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
        Debug.DrawLine(playerPos + (Vector3)boxCollider.offset, playerPos + (Vector3)boxCollider.offset + Vector3.down * boxCollider.bounds.extents.y);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 playerPos = transform.position;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(playerPos + (Vector3)boxCollider.offset, boxCollider.bounds.size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerPos + (Vector3)boxCollider.offset + Vector3.down * 0.1f, boxCollider.bounds.size);
    }
}
