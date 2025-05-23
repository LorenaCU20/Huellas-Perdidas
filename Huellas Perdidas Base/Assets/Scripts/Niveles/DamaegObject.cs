using UnityEngine;

public class DamageObject : MonoBehaviour
{

    [Header("Daño al Jugador")]
    [SerializeField] private int danoAlJugador = 20;

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
    }
}
