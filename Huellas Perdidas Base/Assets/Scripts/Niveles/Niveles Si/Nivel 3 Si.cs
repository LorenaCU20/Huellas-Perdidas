using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_Si : MonoBehaviour
{ 
    public void Siguiente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Reintentar");
    }

    public void Inventario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 16);
        Debug.Log("Inventario");
    }
       
    public void Menu_P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 19);
        Debug.Log("Menú Principal");
    }
}
