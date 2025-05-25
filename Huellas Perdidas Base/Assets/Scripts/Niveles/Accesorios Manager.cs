using UnityEngine;

public class AccesoriosManager : MonoBehaviour
{
    public GameObject gorro1;
    public GameObject gorro2;
    public GameObject collar;

    void Start()
    {
        // Activar accesorios guardados según niveles completados
        if (PlayerPrefs.GetInt("Nivel1Completado", 0) == 1)
            gorro1.SetActive(true);

        if (PlayerPrefs.GetInt("Nivel2Completado", 0) == 1)
            gorro2.SetActive(true);

        if (PlayerPrefs.GetInt("Nivel3Completado", 0) == 1)
            collar.SetActive(true);
    }

    // Llamar este método cuando el jugador complete un nivel
    public void DesbloquearAccesorio(int nivel)
    {
        switch (nivel)
        {
            case 1:
                PlayerPrefs.SetInt("Nivel1Completado", 1);
                gorro1.SetActive(true);
                break;
            case 2:
                PlayerPrefs.SetInt("Nivel2Completado", 1);
                gorro2.SetActive(true);
                break;
            case 3:
                PlayerPrefs.SetInt("Nivel3Completado", 1);
                collar.SetActive(true);
                break;
        }

        PlayerPrefs.Save(); // Guarda los cambios
    }
}
