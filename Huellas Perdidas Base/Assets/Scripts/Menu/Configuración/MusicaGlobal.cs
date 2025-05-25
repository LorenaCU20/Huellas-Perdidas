using UnityEngine;

public class MusicaGlobal : MonoBehaviour
{
    private static MusicaGlobal instancia;

    void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        float volumen = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = volumen;

        if (!audio.isPlaying)
            audio.Play();
    }
}
