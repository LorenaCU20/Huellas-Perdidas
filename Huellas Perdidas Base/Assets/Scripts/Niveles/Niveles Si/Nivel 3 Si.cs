using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_Si : MonoBehaviour
{ 
    public void Siguiente()
    {
        SceneManager.LoadScene("Niveles 4");
        Debug.Log("Reintentar");
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
