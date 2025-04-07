using UnityEngine;

public class Botonesseleccionanimal : MonoBehaviour
{
    void OnGUI()
    {

        var textobutton = new GUIContent("Perro");
        var rectButton = new Rect(400, 300, 100, 50);
        if (GUI.Button(rectButton, textobutton))
        {
            Debug.Log("Menú Perros");
        }
        var textobutton2 = new GUIContent("Gato");
        var rectButton2 = new Rect(600, 300, 100, 50);
        if (GUI.Button(rectButton2, textobutton2))
        {
            Debug.Log("Menú Gatos");
        }
    }
}
