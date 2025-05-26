using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaAlTocar : MonoBehaviour
{
    [SerializeField] private string nombreEscena = "Nivel Si"; // Escena a la que se cambiará

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entró en el trigger tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Guardar la escena actual antes de cambiar
            PlayerPrefs.SetString("ultimaEscena", SceneManager.GetActiveScene().name);

            // Cambiar a la nueva escena
            SceneManager.LoadScene(nombreEscena);
        }
    }
}