using UnityEngine;

public class ProyectilAnimado : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaMaxima = 10f;
    public Vector2 direccion = Vector2.right;

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
    if (collision.CompareTag("Enemigo"))
    {
        // Buscar el script del enemigo y llamarlo
        EnemigoRaton enemigo = collision.GetComponent<EnemigoRaton>();
        if (enemigo != null)
        {
            enemigo.Morir();
        }
         // Si es el gato malo
        GatoMalo gato = collision.GetComponent<GatoMalo>();
        if (gato != null)
        {
            gato.RecibirDanio();
        }

        Destroy(gameObject); // La bola se destruye también
    }
    else if (collision.CompareTag("Obstaculo"))
    {
        Destroy(gameObject);
    }
}
}
