using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Niveles 1");
    }

    public void Inventario()
    {
        SceneManager.LoadScene("Accesorios");
    }

    public void Configuracion()
    {
        SceneManager.LoadScene("Configuración");
    }

    public void Salir() 
    {
        Debug.Log("Saliendo del Juego");
        Application.Quit();
    }
   
}
