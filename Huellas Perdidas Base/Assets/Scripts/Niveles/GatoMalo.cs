using UnityEngine;
using UnityEngine.SceneManagement;
public class GatoMalo : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject prefabBolaPelo; // ← Este aparecerá en el inspector
    public Transform puntoDisparo;    // ← Este también aparecerá
    public int vida = 3;


    public float tiempoEntreDisparos = 3f;

    void Start()
    {
        Debug.Log("👀 Start() del GatoMalo ha sido ejecutado");
        InvokeRepeating(nameof(Disparar), 1f, tiempoEntreDisparos);
    }

    void Disparar()
{
    Debug.Log("🧶 Disparando bola de pelo...");

    GameObject bola = Instantiate(prefabBolaPelo, puntoDisparo.position, Quaternion.identity);
    Debug.Log("📍 Bola instanciada en: " + puntoDisparo.position);

    BolaPelo script = bola.GetComponent<BolaPelo>();
    if (script != null)
    {
        script.direccion = Vector2.left;
    }
    else
    {
        Debug.LogWarning("⚠️ La bola de pelo no tiene el script BolaPelo.cs");
    }
}

    public void RecibirDanio()
    {
        // Por ejemplo, vida simple de 3 puntos
        vida--;

        Debug.Log("🔥 Gato malo recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject);
            Debug.Log("💀 Gato malo destruido.");
        }
    }

}
