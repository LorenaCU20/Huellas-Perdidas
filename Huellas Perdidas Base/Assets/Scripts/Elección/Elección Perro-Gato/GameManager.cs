using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Controla funcionamientos del personaje
    public List<PersonajesSelección> personajes; //Lista para almacenar los personajes
    public PersonajesSelección personajeSeleccionado; // ← guardará el personaje seleccionado


    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
