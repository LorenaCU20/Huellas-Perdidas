using UnityEngine;

public class BolaPelo : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;
    public Vector2 direccion = Vector2.left; // Se puede cambiar desde el script del gato
    private Vector3 puntoInicio;
    [SerializeField] private float distanciaMaxima = 30f;

    void Start()
    {
        puntoInicio = transform.position;

        // Ignorar colisión con todas las bolas de fuego activas
        ProyectilAnimado[] bolasFuego = FindObjectsOfType<ProyectilAnimado>();
        foreach (var bola in bolasFuego)
        {
            Collider2D col1 = GetComponent<Collider2D>();
            Collider2D col2 = bola.GetComponent<Collider2D>();
            if (col1 != null && col2 != null)
            {
                Physics2D.IgnoreCollision(col1, col2);
            }
        }
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, puntoInicio) > distanciaMaxima)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovimientoJugador jugador = collision.GetComponent<MovimientoJugador>();
            if (jugador != null)
            {
                jugador.RecibirDanio(35);
            }
            Destroy(gameObject);
        }
        else if (collision.GetComponent<ProyectilAnimado>())
        {
            // Ya no destruye la otra bola, solo a sí misma
            Destroy(gameObject);
        }
    }
}
