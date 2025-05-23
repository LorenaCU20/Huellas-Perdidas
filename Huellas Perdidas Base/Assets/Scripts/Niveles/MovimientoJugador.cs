using UnityEngine;
using System.Collections;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento; // Velocidad de desplazamiento del jugador
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento; // Suavizado para el movimiento (movimiento más fluido)
    private Vector3 velocidad = Vector3.zero; // Velocidad actual usada por SmoothDamp
    private bool mirandoDerecha = true; // Indica si el jugador está mirando hacia la derecha

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto; // Fuerza aplicada al salto
    [SerializeField] private LayerMask queEsSuelo; // Capa que se considera suelo
    [SerializeField] private Transform controladorSuelo; // Punto desde donde se detecta si el jugador está en el suelo
    [SerializeField] private Vector3 dimensionesCaja; // Tamaño de la caja para comprobar el suelo
    [SerializeField] private bool enSuelo; // Indica si el jugador está tocando el suelo
    private bool salto = false; // Indica si se debe saltar en el siguiente FixedUpdate

    [Header("Animacion")]
    private Animator animator; // Referencia al componente Animator

    [Header("Vida")]
    [SerializeField] private int vidaMaxima = 100; // Valor máximo de vida
    private int vidaActual; // Vida actual del jugador

    [Header("Invulnerabilidad")]
    private bool invulnerable = false; // Estado de invulnerabilidad tras recibir daño
    private SpriteRenderer spriteRenderer; // Para hacer parpadeo durante la invulnerabilidad
    [SerializeField] private float tiempoInvulnerabilidad = 1.5f; // Duración de la invulnerabilidad
    [SerializeField] private LayerMask capaEnemigo; // Capa de enemigos para ignorar colisiones temporalmente

    private void Start()
    {
        // Inicializar componentes
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        vidaActual = vidaMaxima;
    }

    private void Update()
    {
        // Obtener entrada horizontal (teclas A/D o flechas)
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        // Detectar salto
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        // Verificar si está tocando el suelo
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        // Aplicar movimiento y salto
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        // Reiniciar salto
        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        // Movimiento horizontal suavizado
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        // Girar el personaje según la dirección del movimiento
        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        // Aplicar salto si está en el suelo
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    private void Girar()
    {
        // Cambiar dirección visual del personaje
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        // Dibuja una caja en la escena para visualizar el área de detección de suelo
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    public void RecibirDanio(int cantidad)
    {
        // Si es invulnerable, no recibe daño
        if (invulnerable) return;

        // Reducir vida
        vidaActual -= cantidad;
        Debug.Log("Vida actual del jugador: " + vidaActual);

        // Si la vida llega a 0, morir
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }
        else
        {
            // Activar invulnerabilidad temporal
            StartCoroutine(Invulnerabilidad());
        }
    }

    public void Curar(int cantidad)
    {
        // Aumentar vida
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }

    private void Morir()
    {
        // Acción al morir (puede reemplazarse con animación, reinicio, etc.)
        Debug.Log("El personaje ha muerto.");
        gameObject.SetActive(false);
    }

    private IEnumerator Invulnerabilidad()
    {
        invulnerable = true;

        // Ignorar colisiones con enemigos
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMaskToLayer(capaEnemigo), true);

        float tiempo = 0f;
        // Parpadeo del sprite
        while (tiempo < tiempoInvulnerabilidad)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.2f);
            tiempo += 0.2f;
        }

        // Restaurar estado normal
        spriteRenderer.enabled = true;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMaskToLayer(capaEnemigo), false);
        invulnerable = false;
    }

    // Convierte un LayerMask a su índice de capa (0-31)
    private int LayerMaskToLayer(LayerMask mask)
    {
        int layer = 0;
        int bitmask = mask.value;
        while (bitmask > 1)
        {
            bitmask = bitmask >> 1;
            layer++;
        }
        return layer;
    }
}
