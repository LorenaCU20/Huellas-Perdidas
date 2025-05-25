using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Controla funcionamientos del personaje
    public List<PersonajesSelección> personajes; //Lista para almacenar los personajes

    private void Awake()
    {
        if(GameManager.Instance==null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject );
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
