using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_2_No : MonoBehaviour
{
    public void Inventario()
    {
        SceneManager.LoadScene("Accesorios");
        Debug.Log("Inventario");
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("N2 Gato 1");
        Debug.Log("Reintentar");
    }
    public void Menu_P()
    {
        SceneManager.LoadScene("Menu Principal");
        Debug.Log("Menú Principal");
    }
}
