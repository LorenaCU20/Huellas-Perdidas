using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;// Contiene la clase Image (para mostrar imágenes en UI)
using TMPro;// Para usar TextMeshProUGUI (texto moderno con mejor rendimiento)
using UnityEngine.SceneManagement;// Para cambiar escenas en el juego
using Unity.VisualScripting;
public class MenuSeleccionPersonaje : MonoBehaviour
{
   private int index; //Index de referencia para los personajes
    [SerializeField] private UnityEngine.UI.Image imagen;
   private GameManager gameManager; // Referencia al GameManager (clase que contiene la lista de personajes y lógica global)

    private void Start()
    {
        gameManager = GameManager.Instance; // Obtener la instancia del GameManager (asumiendo que implementa Singleton)

        index = PlayerPrefs.GetInt("JugadorIndex"); // Leer el índice previamente guardado del personaje desde PlayerPrefs

        if(index>gameManager.personajes.Count - 1) // Si el índice guardado es mayor que el total de personajes disponibles, se reinicia
        {
            index=0;
        }

        CambiarPantalla(); // Actualiza la interfaz con la información del personaje actual
    }

    private void CambiarPantalla()
    { // Actualiza la imagen y el nombre del personaje actual en pantalla
        PlayerPrefs.SetInt("JugadorIndex", index); // Guarda el índice actual para mantenerlo entre escenas
        imagen.sprite = gameManager.personajes[index].imagen;
    }

    public void SiguientePersonaje(){ // Cambia al siguiente personaje en la lista
        if(index==gameManager.personajes.Count - 1){ // Si está al final de la lista, vuelve al primero
            index=0;
        }
        else{
            index +=1;
        }

        CambiarPantalla();
    }

    public void AnteriorPersonaje(){ // Cambia al personaje anterior en la lista
        if(index==0){ // Si está al inicio de la lista, va al último
            index=gameManager.personajes.Count - 1;
        }
        else{
            index -=1;
        }

        CambiarPantalla();
    }

    public void IniciarJuego(){ // Carga la siguiente escena (por ejemplo, iniciar el juego)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
