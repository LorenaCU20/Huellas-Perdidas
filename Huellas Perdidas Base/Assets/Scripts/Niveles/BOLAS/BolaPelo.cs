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
            Destroy(collision.gameObject); // destruye la bola de fuego
            Destroy(gameObject); // destruye la bola de pelos
        }
    }
}
