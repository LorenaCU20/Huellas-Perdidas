using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine.Samples;

public class BarraVida : MonoBehaviour
{
    public Image RellenoBarraVida;
    private MovimientoJugador Movimiento_Jugador;
    private int VidaMax;

    void Start()
    {
        // Busca el primer objeto en la escena con el tag "Player"
        GameObject jugadorConTag = GameObject.FindGameObjectWithTag("Player");

        if (jugadorConTag != null)
        {
            Movimiento_Jugador = jugadorConTag.GetComponent<MovimientoJugador>();

            if (Movimiento_Jugador != null)
            {
                VidaMax = Movimiento_Jugador.vidaMaxima;
            }
            else
            {
                Debug.LogWarning("El objeto con tag 'Player' no tiene el componente MovimientoJugador.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Player' en la escena.");
        }
    }

    void Update()
    {
        if (Movimiento_Jugador != null && Movimiento_Jugador.vidaMaxima > 0)
        {
            RellenoBarraVida.fillAmount = (float)Movimiento_Jugador.vidaActual / Movimiento_Jugador.vidaMaxima;
        }
    }
}
