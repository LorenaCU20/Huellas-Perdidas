using UnityEngine;
using System.Collections;

public class ActivadorPorTiempo : MonoBehaviour
{
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

            gameObject.SetActive(true);
            yield return new WaitForSeconds(duracionEncendido);
            gameObject.SetActive(false);
        }
    }
}
