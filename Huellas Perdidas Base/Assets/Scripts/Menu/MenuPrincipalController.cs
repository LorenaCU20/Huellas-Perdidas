using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuPrincipalController : MonoBehaviour
{
    [SerializeField] private GameObject panelSeleccionJuego;

    private string rutaGuardado = Application.persistentDataPath + "/guardado.json";

    public void AlPulsarJugar()
    {
        // Mostrar el panel si existe un archivo guardado
        if (File.Exists(rutaGuardado))
        {
            panelSeleccionJuego.SetActive(true);
        }
        else
        {
            IniciarNuevoMundo();
        }
    }

    public void ContinuarPartida()
    {
        SceneManager.LoadScene("Nivel 1"); // Ajusta el nombre según tu escena
    }

    public void IniciarNuevoMundo()
    {
        // Borrar archivo de guardado si existe
        if (File.Exists(rutaGuardado))
        {
            File.Delete(rutaGuardado);
            Debug.Log("Archivo de guardado eliminado.");
        }

        SceneManager.LoadScene("Nivel 1"); // Empieza desde cero
    }
}
// Este script controla el menú principal del juego. Permite al jugador iniciar un nuevo juego o continuar desde un guardado existente.