using UnityEngine;
using UnityEngine.UI;

public class MostrarImagenPersonajeUI : MonoBehaviour
{
    public Image imagenPersonaje;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.personajeSeleccionado != null)
        {
            imagenPersonaje.sprite = GameManager.Instance.personajeSeleccionado.imagen;
        }
        else
        {
            Debug.LogWarning("⚠️ No se pudo cargar la imagen del personaje seleccionado.");
        }
    }
}
