    using UnityEngine;
    using UnityEngine.SceneManagement;


    public class MenuPausa : MonoBehaviour
    {
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject botonPausa;
    private bool juegoPausado = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }   
    }
        public void Pausa()
        {
            Time.timeScale = 0f; 
            botonPausa.SetActive(false);
            menuPausa.SetActive(true);
        }

        public void Reanudar()
        {
            Time.timeScale = 1f; 
            botonPausa.SetActive(true); 
            menuPausa.SetActive(false);
        }

        public void reiniciar()
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

                public void Configuracion()
        {
            SceneManager.LoadScene("Configuración");
        }

        public void Salir()
        {
            SceneManager.LoadScene("Menu Principal");
        }
    }
