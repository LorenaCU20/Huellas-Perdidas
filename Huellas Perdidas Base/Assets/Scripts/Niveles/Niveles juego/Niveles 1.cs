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
        string escenaActualN1 = SceneManager.GetActiveScene().name;

        switch (escenaActualN1)
        {
            case "Niveles 1 Gato 1":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Gato 2":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Gato 3":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Gato 4":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Perro 1":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Perro 2":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Perro 3":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            case "Niveles 1 Perro 4":
                SceneManager.LoadScene("Nivel 1_Si");
                break;
            default:
                Debug.LogWarning("?? Escena actual no reconocida en el switch: " + escenaActualN1);
                break;
        }
        
    }
    public void Menu_P()
    {
        SceneManager.LoadScene("Menu Principal");
    }

}
