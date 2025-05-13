using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nombremascota : MonoBehaviour
{
    
public int NUMEROMAXIMO;
public int NUMEROMINIMO;
public Text NUMERO;
public void TEXTOANUMERO(string p)
{
    if (int.TryParse(p, out _))
    {
        NUMERO.text = Mathf.Clamp(int.Parse (p), NUMEROMINIMO, NUMEROMAXIMO).ToString();
    }
    else NUMERO.text = "NO";
}
}
