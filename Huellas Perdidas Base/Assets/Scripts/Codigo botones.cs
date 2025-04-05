using UnityEngine;

public class Codigobotones : MonoBehaviour
{
    //Si lo mata puede volver a aparecer, sirve para un boton de revivir para el jugador

    void OnGUI()
    {
        var textobutton = new GUIContent("Jugar");
        var rectButton = new Rect(0, 0, 100, 50);
        if (GUI.Button(rectButton, textobutton))
        {
            Debug.Log("Boton presionado");
        }
    }
}