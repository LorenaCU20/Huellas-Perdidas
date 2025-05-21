using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 nuevaVelocidad = rb2D.linearVelocity;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            nuevaVelocidad.x = runSpeed;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            nuevaVelocidad.x = -runSpeed;
            spriteRenderer.flipX = true;
        }
        else
        {
            nuevaVelocidad.x = 0;
        }

        if (Input.GetKey("w") && CheckGround.isGrounded)
        {
            nuevaVelocidad.y = jumpSpeed;
        }
    }
}
