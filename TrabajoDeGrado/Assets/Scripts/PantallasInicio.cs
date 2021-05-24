using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallasInicio : MonoBehaviour
{

    public GameObject pantalla;
    public GameObject pantalla1;
    public GameObject pantalla2;
    public GameObject pantallaPrincipal;
    public GameObject pantallaFin;
    // Start is called before the first frame update
    void Start()
    {
        pantallaFin.SetActive(false);
        pantalla.SetActive(true);
        pantalla1.SetActive(false);
        pantalla2.SetActive(false);
        pantallaPrincipal.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void PantallaUno(){
        pantalla.SetActive(false);
        pantalla1.SetActive(true);
    }

    public void PantallaDos(){
        pantalla1.SetActive(false);
        pantalla2.SetActive(true);
    }

    public void Iniciiar(){
        pantalla2.SetActive(false);
        pantallaPrincipal.SetActive(true);
        Time.timeScale = 1;
    }
}
