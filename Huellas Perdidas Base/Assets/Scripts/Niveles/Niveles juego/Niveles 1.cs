using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles_1 : MonoBehaviour
{
    public void Nivel_1()
    {
        Debug.Log("El personaje gano");
        string escenaActualN = SceneManager.GetActiveScene().name;

        switch (escenaActualN)
        {
            case "Niveles 1 Gato 1":
                SceneManager.LoadScene("N1 Gato 1");
                break;
            case "Niveles 1 Gato 2":
                SceneManager.LoadScene("N1 Gato 2");
                break;
            case "Niveles 1 Gato 3":
                SceneManager.LoadScene("N1 Gato 3");
                break;
            case "Niveles 1 Gato 4":
                SceneManager.LoadScene("N1 Gato 4");
                break;
            case "Niveles 1 Perro 1":
                SceneManager.LoadScene("N1 Perro 1");
                break;
            case "Niveles 1 Perro 2":
                SceneManager.LoadScene("N1 Perro 2");
                break;
            case "Niveles 1 Perro 3":
                SceneManager.LoadScene("N1 Perro 3");
                break;
            case "Niveles 1 Perro 4":
                SceneManager.LoadScene("N1 Perro 4");
                break;
            default:
                Debug.LogWarning("?? Escena actual no reconocida en el switch: " + escenaActualN);
                break;
        }
        
    }
    public void Menu_P()
    {
        SceneManager.LoadScene("Menu Principal");
    }

}
