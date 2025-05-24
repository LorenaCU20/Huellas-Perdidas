using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles_4 : MonoBehaviour
{
    public void Nivel_1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 14);
    }
    public void Nivel_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);  
    }
    public void Nivel_3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void Menu_P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 19);
    }

}
