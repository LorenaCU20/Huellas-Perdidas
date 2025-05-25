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
        Movimiento_Jugador = GameObject.Find("Jugador").GetComponent<MovimientoJugador>();
        VidaMax = Movimiento_Jugador.vidaMaxima;
    }
    void Update()
    {
        RellenoBarraVida.fillAmount = (float)Movimiento_Jugador.vidaActual / Movimiento_Jugador.vidaMaxima;
    }
}
