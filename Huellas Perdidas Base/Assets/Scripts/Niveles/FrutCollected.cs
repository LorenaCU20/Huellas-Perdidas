using UnityEngine;

public class FrutCollected : MonoBehaviour
{
    public string tipoDeFruta; // "Fresa" o "Manzana"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Contador
            if (FruitCounter.instancia != null)
            {
                FruitCounter.instancia.AgregarFruta(tipoDeFruta);
            }

            // Efecto visual
            GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
