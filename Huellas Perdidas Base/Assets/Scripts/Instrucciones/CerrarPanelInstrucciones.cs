using UnityEngine;

public class CerrarPanelInstrucciones : MonoBehaviour
{
    [SerializeField] private GameObject panelInstrucciones;

    public void CerrarPanel()
    {
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(false);
        }
        else
        {
            Debug.LogError("⚠️ No has asignado el PanelInstrucciones en el inspector.");
        }
    }
    
}
