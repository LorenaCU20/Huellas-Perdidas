using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_Si : MonoBehaviour
{
    public void Inventario()
    {
        SceneManager.LoadScene("Accesorios");
        Debug.Log("Inventario");
    }

    public void Siguiente()
    {
        Debug.Log("El personaje ha muerto.");
        string escenaActual = SceneManager.GetActiveScene().name;

        switch (escenaActual)
        {
            case "Nivel 1_Si Gato 1":
                SceneManager.LoadScene("Niveles 2 Gato 1");
                break;
            case "Nivel 1_Si Gato 2":
                SceneManager.LoadScene("Niveles 2 Gato 2");
                break;
            case "Nivel 1_Si Gato 3":
                SceneManager.LoadScene("Niveles 2 Gato 3");
                break;
            case "Nivel 1_Si Gato 4":
                SceneManager.LoadScene("Niveles 2 Gato 4");
                break;
            case "Nivel 2_Si Gato 1":
                SceneManager.LoadScene("Niveles 3 Gato 1");
                break;
            case "Nivel 2_Si Gato 2":
                SceneManager.LoadScene("Niveles 3 Gato 2");
                break;
            case "Nivel 2_Si Gato 3":
                SceneManager.LoadScene("Niveles 3 Gato 3");
                break;
            case "Nivel 2_Si Gato 4":
                SceneManager.LoadScene("Niveles 3 Gato 4");
                break;
            case "Nivel 3_Si Gato 1":
                SceneManager.LoadScene("Niveles 4 Gato 1");
                break;
            case "Nivel 3_Si Gato 2":
                SceneManager.LoadScene("Niveles 4 Gato 2");
                break;
            case "Nivel 3_Si Gato 3":
                SceneManager.LoadScene("Niveles 4 Gato 3");
                break;
            case "Nivel 3_Si Gato 4":
                SceneManager.LoadScene("Niveles 4 Gato 4");
                break;
            case "Nivel 1_Si Perro 1":
                SceneManager.LoadScene("Niveles 2 Perro 1");
                break;
            case "Nivel 1_Si Perro 2":
                SceneManager.LoadScene("Niveles 2 Perro 2");
                break;
            case "Nivel 1_Si Perro 3":
                SceneManager.LoadScene("Niveles 2 Perro 3");
                break;
            case "Nivel 1_Si Perro 4":
                SceneManager.LoadScene("Niveles 2 Perro 4");
                break;
            case "Nivel 2_Si Perro 1":
                SceneManager.LoadScene("Niveles 3 Perro 1");
                break;
            case "Nivel 2_Si Perro 2":
                SceneManager.LoadScene("Niveles 3 Perro 2");
                break;
            case "Nivel 2_Si Perro 3":
                SceneManager.LoadScene("Niveles 3 Perro 3");
                break;
            case "Nivel 2_Si Perro 4":
                SceneManager.LoadScene("Niveles 3 Perro 4");
                break;
            case "Nivel 3_Si Perro 1":
                SceneManager.LoadScene("Niveles 4 Perro 1");
                break;
            case "Nivel 3_Si Perro 2":
                SceneManager.LoadScene("Niveles 4 Perro 2");
                break;
            case "Nivel 3_Si Perro 3":
                SceneManager.LoadScene("Niveles 4 Perro 3");
                break;
            case "Nivel 3_Si Perro 4":
                SceneManager.LoadScene("Niveles 4 Perro 4");
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
