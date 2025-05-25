using UnityEngine;

public class CerrarPanelInstrucciones : MonoBehaviour
{
    public GameObject panelInstrucciones;

    public void CerrarPanel()
    {
        panelInstrucciones.SetActive(false);
    }
}
