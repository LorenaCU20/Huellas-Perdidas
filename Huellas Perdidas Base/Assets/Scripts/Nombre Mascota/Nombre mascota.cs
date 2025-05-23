using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NombreMascota : MonoBehaviour
{
    public TMP_InputField imputText;
    public TMP_Text textoNombre;
    public Image Luz;
    public GameObject BotonAceptar;

    private void Awake()
    {
        Luz.color = Color.red;

        // Asegura que el texto empiece en mayúsculas si hay texto pre-cargado
        ConvertirMayusculas(imputText.text);

        // Suscribimos el método a cada cambio en el input
        imputText.onValueChanged.AddListener(ConvertirMayusculas);
    }

    void Update()
    {
        if (textoNombre.text.Length < 4)
        {
            Luz.color = new Color(0.6f, 0f, 0f);
            BotonAceptar.SetActive(false);
        }
        else
        {
            Luz.color = new Color(0f, 0.6f, 0f);
            BotonAceptar.SetActive(true);
        }
    }

    public void aceptar()
    {
        PlayerPrefs.SetString("nombre1", imputText.text.ToUpper()); // también se guarda en mayúscula
        SceneManager.LoadScene("Niveles 1");
    }

    // Método que convierte el texto a mayúsculas
    private void ConvertirMayusculas(string texto)
    {
        string mayus = texto.ToUpper();
        imputText.text = mayus;
        textoNombre.text = mayus;
    }
}