using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonRegresar : MonoBehaviour
{
    public void IrAEscenaDeseada()
    {
        SceneManager.LoadScene("Menu Principal"); // Reemplaza con el nombre real de tu escena
    }
}
