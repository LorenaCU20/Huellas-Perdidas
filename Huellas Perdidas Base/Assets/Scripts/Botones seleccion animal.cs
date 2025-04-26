using UnityEngine;
using UnityEngine.SceneManagement;

public class Botonesseleccionanimal : MonoBehaviour
{
    void OnGUI()
    {

        var textobutton = new GUIContent("Perro");
        var rectButton = new Rect(400, 300, 100, 50);
        if (GUI.Button(rectButton, textobutton))
        {
            Debug.Log("Menú Perros");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        var textobutton2 = new GUIContent("Gato");
        var rectButton2 = new Rect(600, 300, 100, 50);
        if (GUI.Button(rectButton2, textobutton2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Debug.Log("Menú Gatos");
        }
    }
}
