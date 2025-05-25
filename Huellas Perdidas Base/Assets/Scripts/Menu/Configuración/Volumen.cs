using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    public Image imagenSonando;
    public AudioSource musica;
    public Toggle toggleMute;

    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        slider.value = sliderValue;

        AudioListener.volume = sliderValue;
        if (musica != null) musica.volume = sliderValue;

        // 🔁 Este evento hace que si el toggle está activado, mutee
        toggleMute.isOn = false; // Siempre iniciar desactivado
        toggleMute.onValueChanged.AddListener(delegate { ActivarMute(toggleMute.isOn); });

        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);

        AudioListener.volume = valor;
        if (musica != null) musica.volume = valor;

        RevisarSiEstoyMute();

        // 🔁 Si el volumen ya no es 0, desactiva el toggle mute automáticamente
        if (valor > 0.01f && toggleMute.isOn)
        {
            toggleMute.isOn = false;
        }
    }

    public void RevisarSiEstoyMute()
    {
        bool estaMuteado = sliderValue <= 0.01f;
        imagenMute.enabled = estaMuteado;
        imagenSonando.enabled = !estaMuteado;
    }

    public void ActivarMute(bool estaActivado)
    {
        if (estaActivado)
        {
            slider.value = 0f;
            ChangeSlider(0f);
        }
    }
}
