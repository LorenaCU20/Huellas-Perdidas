using UnityEngine;

public class CodigoBotones2 : MonoBehaviour
{
    private int currentIndexGUI;
    private void OnGUI()
    {
        var toolbarRect = new Rect(Screen.width / 2f, Screen.height / 2f, 200, 25);
        currentIndexGUI = GUI.Toolbar(toolbarRect, currentIndexGUI, new string[2]
        {
            "GUI",
            "GUILayout"
        });
        switch (currentIndexGUI)
        {
            case 0:
                var topLeft = new Rect(0, 0, 100, 50);
                GUI.Box(topLeft, "Arriba izquierda");

                var bottomLeft = new Rect(0, Screen.height - 50, 100, 50);
                GUI.Box(bottomLeft, "Abajo izquierda");

                var topRight = new Rect(Screen.width - 100, 0, 100, 50);
                GUI.Box(topRight, "Arriba Derecha");

                var bottomRight = new Rect(Screen.width-100, Screen.height - 50, 100, 50);
                GUI.Box(bottomRight, "Abajo Derecha");
                break;
            case 1:
                var textobutton = new GUIContent("Jugar");
                var rectButton = new Rect(0, 0, 100, 50);
                if (GUI.Button(rectButton, textobutton))
                {
                    Debug.Log("Boton presionado");
                }
                break;
        }
    }
}
