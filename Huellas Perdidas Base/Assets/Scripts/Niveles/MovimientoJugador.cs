using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MovimientoJugador : MonoBehaviour
{
    // Referencia al componente Rigidbody2D para aplicar físicas
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f; // Entrada del jugador en el eje horizontal
    [SerializeField] private float velocidadDeMovimiento; // Velocidad de movimiento del jugador
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento; // Suavizado para movimiento fluido
    private Vector3 velocidad = Vector3.zero; // Velocidad usada por SmoothDamp
    private bool mirandoDerecha = true; // Dirección del jugador

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto; // Fuerza del salto
    [SerializeField] private LayerMask queEsSuelo; // Capas consideradas como suelo
    [SerializeField] private Transform controladorSuelo; // Posición desde la cual se detecta el suelo
    [SerializeField] private Vector3 dimensionesCaja; // Tamaño de la caja para detección de suelo
    [SerializeField] private bool enSuelo; // Si el jugador está tocando el suelo
    private bool salto = false; // Si el jugador debe saltar en el próximo FixedUpdate

    [Header("Animacion")]
    private Animator animator; // Referencia al componente Animator

    [Header("Vida")]
    [SerializeField] public int vidaMaxima = 100; // Vida máxima del jugador
    public int vidaActual; // Vida actual del jugador

    [Header("Invulnerabilidad")]
    private bool invulnerable = false; // Si el jugador es invulnerable actualmente
    private SpriteRenderer spriteRenderer; // Para hacer parpadeo visual durante invulnerabilidad
    [SerializeField] private float tiempoInvulnerabilidad = 1.5f; // Duración de la invulnerabilidad
    [SerializeField] private LayerMask capaEnemigo; // Capa que se ignora temporalmente al recibir daño

    private void Start()
    {
        // Obtener referencias a los componentes necesarios
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        vidaActual = vidaMaxima; // Inicializar vida
    }

    private void Update()
    {
        // Obtener entrada horizontal (A/D o flechas)
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        // Detectar salto cuando se presiona la tecla de salto
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        // Verificar si el jugador está en el suelo usando OverlapBox
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("ensuelo", enSuelo);

        // Aplicar movimiento y salto
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        // Reiniciar salto para que no se repita
        salto = false;
    }

    // Método que maneja el movimiento del jugador
    private void Mover(float mover, bool saltar)
    {
        // Movimiento horizontal suavizado
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        // Girar el personaje si cambia de dirección
        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        // Aplicar salto solo si está en el suelo
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    // Invierte la escala del personaje para que mire en la otra dirección
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    // Dibuja una caja en la escena para visualizar la detección de suelo (solo en editor)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    // Método para recibir daño
    public void RecibirDanio(int cantidad)
    {
        // Si está en modo invulnerable, ignorar el daño
        if (invulnerable) return;

        // Reducir vida actual
        vidaActual -= cantidad;
        Debug.Log("Vida actual del jugador: " + vidaActual);

        // Si la vida llega a 0 o menos, morir
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir(); // Llama al método para morir
        }
        else
        {
            // Activar invulnerabilidad temporal
            StartCoroutine(Invulnerabilidad());
        }
    }

    // Método para curar al jugador
    public void Curar(int cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }

    // Acción al morir el personaje
    private void Morir()
    {
        Debug.Log("El personaje ha muerto.");
        SceneManager.LoadScene("Nivel 1_No"); // Cambiar de escena al morir
    }

    // Corrutina que activa invulnerabilidad temporal y efecto visual de parpadeo
    private IEnumerator Invulnerabilidad()
    {
        invulnerable = true;

        // Ignorar colisiones con enemigos
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMaskToLayer(capaEnemigo), true);

        float tiempo = 0f;

        // Parpadeo del sprite (encender/apagar cada 0.2 segundos)
        while (tiempo < tiempoInvulnerabilidad)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.2f);
            tiempo += 0.2f;
        }

        // Restaurar visibilidad y colisiones normales
        spriteRenderer.enabled = true;
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMaskToLayer(capaEnemigo), false);
        invulnerable = false;
    }

    // Convierte un LayerMask a un índice de capa (0–31)
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
