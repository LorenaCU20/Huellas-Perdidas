using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Nivel_3_Si : MonoBehaviour
{
    // Campo para el input de nombre (opcional si aún deseas guardar el nombre)
    public TMP_InputField imputText;

    public void aceptar()
    {
        if (imputText != null && !string.IsNullOrWhiteSpace(imputText.text))
        {
            // Guardar el nombre en mayúsculas
            PlayerPrefs.SetString("nombre1", imputText.text.ToUpper());
        }
        else
        {
            Debug.LogWarning("⚠ El campo de nombre está vacío o no está asignado.");
        }

        // Cargar la escena fija "N2 Gato 1"
        Debug.Log("🔁 Cargando escena: N2 Gato 1");
        SceneManager.LoadScene("N2 Gato 1");
    }

    public void Inventario()
    {
        SceneManager.LoadScene("Accesorios");
        Debug.Log("🧰 Inventario cargado");
    }

    public void Menu_P()
    {
        SceneManager.LoadScene("Menu Principal");
        Debug.Log("🏠 Volviendo al Menú Principal");
    }
}
