using UnityEngine;

public class BolaPelo : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaMaxima = 10f;
    public Vector2 direccion = Vector2.left;

    private Vector3 puntoInicio;

    void Start()
    {
        puntoInicio = transform.position;
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, puntoInicio) >= distanciaMaxima)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si golpea al jugador
        if (collision.CompareTag("Player"))
        {
            MovimientoJugador jugador = collision.GetComponent<MovimientoJugador>();
            if (jugador != null)
            {
                jugador.RecibirDanio(35); // 💥 Daño al jugador
            }

            Destroy(gameObject);
        }

        // Si choca con bola de fuego
        if (collision.GetComponent<ProyectilAnimado>())
        {
            Destroy(collision.gameObject); // destruir bola de fuego
            Destroy(gameObject);           // destruir bola de pelo
        }
    }
}
