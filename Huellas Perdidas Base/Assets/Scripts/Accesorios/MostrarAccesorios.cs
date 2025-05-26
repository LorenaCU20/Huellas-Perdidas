using UnityEngine;
using TMPro;

public class MostrarAccesorios : MonoBehaviour
{
    public Transform contenedorPersonaje; // Asignar el GameObject vacío
    public TMP_Text textoNombre;          // Asignar el texto del nombre

    void Start()
    {
        // Instanciar personaje
        if (GameManager.Instance != null && GameManager.Instance.personajeSeleccionado != null)
        {
            Instantiate(GameManager.Instance.personajeSeleccionado.prefabPersonaje, contenedorPersonaje.position, Quaternion.identity, contenedorPersonaje);
        }

        // Mostrar nombre
        string nombreMascota = PlayerPrefs.GetString("nombre1", "SIN NOMBRE");
        textoNombre.text = nombreMascota;
    }
}
