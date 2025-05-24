using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaAlTocar : MonoBehaviour
{
    [SerializeField] private string nombreEscena = "Nivel 1_Si"; // Escena a la que se cambiará

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entró en el trigger tiene la etiqueta "Jugador"
        if (collision.CompareTag("Player"))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
