using UnityEngine;

public class Ratones : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 2f;

    [Header("Jugador")]
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRadius = 5f;

    [Header("Daño al Jugador")]
    [SerializeField] private int danoAlJugador = 20;

    private bool isFacingRight = true;
    private bool persiguiendo = false;

    private Rigidbody2D rbEnemigo;

    private void Awake()
    {
        rbEnemigo = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Perseguir al jugador
            persiguiendo = true;
            float direccion = Mathf.Sign(player.position.x - transform.position.x);
            rbEnemigo.linearVelocity = new Vector2(direccion * speed, rbEnemigo.linearVelocity.y);

            Flip(direccion > 0);
        }
        else
        {
            // Patrullaje automático
            persiguiendo = false;
            float direccion = isFacingRight ? 1f : -1f;
            rbEnemigo.linearVelocity = new Vector2(direccion * speed, rbEnemigo.linearVelocity.y);
        }
    }

    private void Flip(bool faceRight)
    {
        if (isFacingRight != faceRight)
        {
            isFacingRight = faceRight;
            Vector3 escala = transform.localScale;
            escala.x = Mathf.Abs(escala.x) * (isFacingRight ? 1 : -1);
            transform.localScale = escala;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MovimientoJugador jugador = collision.gameObject.GetComponent<MovimientoJugador>();
            if (jugador != null)
            {
                jugador.RecibirDanio(danoAlJugador);
            }
        }
        else if (collision.gameObject.CompareTag("Obstaculo") && !persiguiendo)
        {
            // Solo cambiar dirección si no está persiguiendo
            Flip(!isFacingRight); // Voltear sprite
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
