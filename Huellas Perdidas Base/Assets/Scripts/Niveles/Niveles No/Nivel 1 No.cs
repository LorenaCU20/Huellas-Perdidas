using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_1_No : MonoBehaviour
{
    public void Inventario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        Debug.Log("Inventario");
    }

    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Debug.Log("Reintentar");
    }
    public void Menu_P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
        Debug.Log("Menú Principal");
    }
}
