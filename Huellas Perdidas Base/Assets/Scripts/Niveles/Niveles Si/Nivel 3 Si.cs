using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_Si : MonoBehaviour
{
    public void Siguiente()
    {
        string ultimaEscena = PlayerPrefs.GetString("ultimaEscena", "");

        if (string.IsNullOrEmpty(ultimaEscena))
        {
            Debug.LogWarning("⚠ No se encontró la escena anterior.");
            return;
        }

        string[] partes = ultimaEscena.Split(' '); // Ej: "Niveles 1 Gato 2"

        if (partes.Length == 4 && partes[0] == "Niveles")
        {
            int nivelActual = int.Parse(partes[1]);
            string tipo = partes[2];
            string numero = partes[3];

            int siguienteNivel = nivelActual + 1;
            string siguienteEscena = $"Niveles {siguienteNivel} {tipo} {numero}";

            Debug.Log("➡ Cargando: " + siguienteEscena);
            SceneManager.LoadScene(siguienteEscena);
        }
        else
        {
            Debug.LogWarning("⚠ Formato no reconocido en 'ultimaEscena': " + ultimaEscena);
        }
    }

    public void Inventario()
    {
        SceneManager.LoadScene("Accesorios");
        Debug.Log("Inventario");
    }

    public void Menu_P()
    {
        SceneManager.LoadScene("Menu Principal");
        Debug.Log("Menú Principal");
    }
}

    