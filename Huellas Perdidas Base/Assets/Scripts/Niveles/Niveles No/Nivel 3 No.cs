using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_No : MonoBehaviour
{
    public void Inventario()
    {
        SceneManager.LoadScene("Accesorios");
        Debug.Log("Inventario");
    }

    public void Reintentar()
    {
        Debug.Log("El personaje ha muerto.");
        string escenaActual = SceneManager.GetActiveScene().name;

        switch (escenaActual)
        {
            case "Nivel 3_No Gato 1":
                SceneManager.LoadScene("N3 Gato 1");
                break;
            case "Nivel 3_No Gato 2":
                SceneManager.LoadScene("N3 Gato 2");
                break;
            case "Nivel 3_No Gato 3":
                SceneManager.LoadScene("N3 Gato 3");
                break;
            case "Nivel 3_No Gato 4":
                SceneManager.LoadScene("N3 Gato 4");
                break;
            case "Nivel 3_No Perro 1":
                SceneManager.LoadScene("N3 Perro 1");
                break;
            case "Nivel 3_No Perro 2":
                SceneManager.LoadScene("N3 Perro 2");
                break;
            case "Nivel 3_No Perro 3":
                SceneManager.LoadScene("N3 Perro 3");
                break;
            case "Nivel 3_No Perro 4":
                SceneManager.LoadScene("N3 Perro 4");
                break;

            default:
                Debug.LogWarning("⚠️ Escena actual no reconocida en el switch: " + escenaActual);
                break;
        }
    }
    public void Menu_P()
    {
        SceneManager.LoadScene("Menu Principal");
        Debug.Log("Menú Principal");
    }
}
