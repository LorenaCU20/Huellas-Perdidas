using UnityEngine;

public class MostrarPersonaje : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.personajeSeleccionado != null)
        {
            // Instancia el prefab del personaje en la posición actual de este objeto
            Instantiate(GameManager.Instance.personajeSeleccionado.prefabPersonaje, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("⚠️ No se encontró el personaje seleccionado.");
        }
    }
}
