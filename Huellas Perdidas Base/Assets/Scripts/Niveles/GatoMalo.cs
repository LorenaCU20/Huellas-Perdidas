using UnityEngine;

public class GatoMalo : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject prefabBolaPelo;         // Prefab de la bola de pelo
    public Transform puntoDisparo;            // Lugar desde donde dispara
    public float tiempoEntreDisparos = 3f;    // Intervalo de disparo en segundos

    [Header("Vida")]
    public int vida = 3;                      // Vida del gato malo

    [Header("Daño al Jugador")]
    [SerializeField] private int danoAlJugador = 20;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (prefabBolaPelo == null || puntoDisparo == null)
        {
            Debug.LogError("❌ Falta asignar el prefab de la bola de pelo o el punto de disparo.");
            return;
        }

        InvokeRepeating(nameof(Disparar), 1f, tiempoEntreDisparos);
    }

    void Disparar()
    {
        Debug.Log("🧶 El gato está disparando...");

        if (animator != null)
        {
            animator.SetTrigger("Disparar");
        }

        GameObject bola = Instantiate(prefabBolaPelo, puntoDisparo.position, Quaternion.identity);

        BolaPelo script = bola.GetComponent<BolaPelo>();
        if (script != null)
        {
            script.direccion = Vector2.left;
        }
        else
        {
            Debug.LogWarning("⚠️ La bola de pelo instanciada no tiene el script 'BolaPelo'");
        }
    }

    public void RecibirDanio()
    {
        vida--;
        Debug.Log("😾 Gato malo recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            // Aquí puedes agregar animación de muerte
            Destroy(gameObject);
            Debug.Log("💀 Gato malo ha muerto.");
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
    }
}