using UnityEngine;
using System.Collections;

public class ActivadorPorTiempo : MonoBehaviour
{
    public GameObject fuegoVisual;  // Asigna el objeto hijo en el Inspector
    public float intervaloMinimo = 4f;
    public float intervaloMaximo = 6f;
    public float duracionEncendido = 1.5f;

    void Start()
    {
        StartCoroutine(ControlarActivacion());
    }

    IEnumerator ControlarActivacion()
    {
        while (true)
        {
            float espera = Random.Range(intervaloMinimo, intervaloMaximo);
            yield return new WaitForSeconds(espera);

            fuegoVisual.SetActive(true);
            yield return new WaitForSeconds(duracionEncendido);
            fuegoVisual.SetActive(false);
        }
    }
}

