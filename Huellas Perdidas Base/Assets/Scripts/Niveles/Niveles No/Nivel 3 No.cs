using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_No : MonoBehaviour
{
    public void Inventario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 15);
        Debug.Log("Inventario");
    }

    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Debug.Log("Reintentar");
    }
    public void Menu_P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 18);
        Debug.Log("Menú Principal");
    }
}
