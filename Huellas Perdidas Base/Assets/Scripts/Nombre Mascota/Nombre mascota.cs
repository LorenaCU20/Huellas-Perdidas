using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class NombreMascota : MonoBehaviour
{
    public TMP_InputField imputText;
    public TMP_Text textoNombre;
    public Image Luz;
    public GameObject BotonAceptar;

    private void Awake()
    {
        Luz.color = Color.red;

        // Convertir texto inicial a mayúsculas
        ConvertirMayusculas(imputText.text);

        // Escuchar cambios en el campo de texto
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
        // Guardar el nombre en mayúsculas para mostrar
        PlayerPrefs.SetString("nombre1", imputText.text.ToUpper());

        if (GameManager.Instance != null && GameManager.Instance.personajeSeleccionado != null)
        {
            // Obtener el nombre del personaje en minúscula (ej: gato3)
            string personajeID = GameManager.Instance.personajeSeleccionado.name.ToLower();

            // Separar tipo y número
            string tipo = new string(personajeID.TakeWhile(char.IsLetter).ToArray());   // gato o perro
            string numero = new string(personajeID.SkipWhile(char.IsLetter).ToArray()); // 1, 2, etc.

            // Capitalizar la primera letra del tipo
            string tipoCapitalizado = char.ToUpper(tipo[0]) + tipo.Substring(1);

            // Generar el nombre de la escena
            string nombreEscena = $"Niveles 1 {tipoCapitalizado} {numero}"; // Ej: "Niveles 1 Gato 2"

            Debug.Log("🔁 Cargando escena: " + nombreEscena);
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogWarning("⚠ No hay personaje seleccionado en el GameManager.");
        }
    }


    private void ConvertirMayusculas(string texto)
    {
        string mayus = texto.ToUpper();
        imputText.text = mayus;
        textoNombre.text = mayus;
    }
}