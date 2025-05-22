using UnityEngine;

public class CheckGround : MonoBehaviour
{
  
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
