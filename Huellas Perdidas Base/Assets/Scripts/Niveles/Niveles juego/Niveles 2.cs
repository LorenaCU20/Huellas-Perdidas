using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles_2 : MonoBehaviour
{
    public void Nivel_1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void Nivel_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu_P()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
    }
}
