using UnityEngine;

public class ControladorOpcionesGlobal : MonoBehaviour
{
    public AudioSource musica;

    private void Start()
    {
        // Cargar volumen si existe
        if (PlayerPrefs.HasKey("volumenAudio"))
            musica.volume = PlayerPrefs.GetFloat("volumenAudio");
    }

    public void CambiarVolumen(float nuevoVolumen)
    {
        musica.volume = nuevoVolumen;
        PlayerPrefs.SetFloat("volumenAudio", nuevoVolumen);
        PlayerPrefs.Save();
    }
}
