using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitCounter : MonoBehaviour
{
    public static FruitCounter instancia;

    public int ChiliRestantes = 8;
    public int PescadoRestantes = 8;
    public int PolloRestantes = 8;

    public TMP_Text textoChili;
    public TMP_Text textoPescado;
    public TMP_Text textoPollo;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        ActualizarUI();
    }

    public void AgregarFruta(string tipo)
    {
        if (tipo == "Chili" && ChiliRestantes > 0)
        {
            ChiliRestantes--;
        }
        else if (tipo == "Pescado" && PescadoRestantes > 0)
        {
            PescadoRestantes--;
        }
        else if (tipo == "Pollo" && PolloRestantes > 0)
        {
            PolloRestantes--;
        }

        ActualizarUI();
    }
    void ActualizarUI()
    {
        textoChili.text = ChiliRestantes.ToString();
        textoPescado.text = PescadoRestantes.ToString();
        textoPollo.text = PolloRestantes.ToString();


    }
}
