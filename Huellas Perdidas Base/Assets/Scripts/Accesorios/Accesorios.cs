using UnityEngine;
using UnityEngine.SceneManagement;

public class Elección : MonoBehaviour
{
    public void Perro ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Menú Perros");
    }
    public void Gato ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("Menú Gatos");
    }
}
