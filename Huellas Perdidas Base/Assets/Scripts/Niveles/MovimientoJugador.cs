using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;//Recibir controles

    [SerializeField] /*Para que aparezca al inicio*/ private float velocidadDeMovimiento; //Velocidad de nuestro personaje
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;//Velocidad en z cero para que no se mueva
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;//Fuerza con la que el personaje va a saltar
    [SerializeField] private LayerMask queEsSuelo;//Superficies sean aptas para que salte, contolador suelo en los pies
    [SerializeField] private Transform controladorSuelo;//Caja alrdedor del objeto
    [SerializeField] private Vector3 dimensionesCaja; //Dimensiones del suelo
    [SerializeField] private bool enSuelo;//Si estamos en el suelo
    private bool salto = false;//Para poder saltar
    [Header("Animacion")]
    private Animator animator;//Referencia a animator de nuestro personaje
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;//Tomar controles del jugador, dirección 

        //Si oprimos el botón saltar queremos que el salto sea verdadero
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }
    private void FixedUpdate()//Cambios en las físicas para que funcione en todos los equipos
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);//Estamos en el sueño mientras la caja toque algo de suelo
        //Mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);//El personaje se mueva a la misma velocidad
        salto = false;
    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);//Para que la velocidad no se vea afectada cuando se mueve
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        //Suavizado al frenar o acelarar, velocidad now, velocidad que se quiere llegar, qué tan rápido

        if (mover > 0 && !mirandoDerecha)
        {
            //Girar
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            //Girar
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }
    private void Girar()//Sentido contrario a la que lo tenemos
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;//Cambio de dirección de personaje
        transform.localScale = escala;
    }
    private void OnDrawGizmos()//Ver la caja que creamos
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);//Dibujar
    }
}
