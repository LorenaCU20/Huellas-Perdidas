using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles_1 : MonoBehaviour
{
    public void Nivel_1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Nivel_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
    }

    public void Nivel_3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu_P() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
   
}
