using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel_3_Si : MonoBehaviour
{
    public void Siguiente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void Inventario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void Menu_P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -12);
    }

   
}
