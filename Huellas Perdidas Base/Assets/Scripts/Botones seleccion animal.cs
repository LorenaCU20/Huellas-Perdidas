using UnityEngine;

public class Botonesseleccionanimal : MonoBehaviour
{
    void OnGUI()
    {
        var texto = new GUIContent("Elige tu mascota");
        var rectButton1 = new Rect(450, 150, 200, 50);
        GUI.Button(rectButton1, texto);

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
