using UnityEngine;

public class CreadorJugador : MonoBehaviour
{
    public GameObject[] gatos;
    public GameObject[] perros;

    void Start()
    {
        string tipo = PlayerPrefs.GetString("TipoMascota", "Gato");
        int index = PlayerPrefs.GetInt("JugadorIndex", 0);

        GameObject prefabElegido = null;

        if (tipo == "Gato" && index < gatos.Length)
        {
            prefabElegido = gatos[index];
        }
        else if (tipo == "Perro" && index < perros.Length)
        {
            prefabElegido = perros[index];
        }

        if (prefabElegido != null)
        {
            Instantiate(prefabElegido, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("❌ No se pudo instanciar el personaje");
        }
    }
}
