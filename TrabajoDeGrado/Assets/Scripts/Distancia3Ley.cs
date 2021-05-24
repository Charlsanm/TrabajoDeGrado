using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distancia3Ley : MonoBehaviour
{

    public GameObject distancia;
    public GameObject pantallaFinal;
    private Vector3 posicionInicial;
    private Vector3 posicionObjeto;
    private Vector3 heading;
    private float distance;
    [SerializeField] TextMeshProUGUI textDistancia;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = distancia.transform.position;
        posicionObjeto = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Distancia();
        if((int)distance==10){
            Time.timeScale = 0;
            pantallaFinal.SetActive(true);
        }
        textDistancia.SetText("DISTANCIA: " + (int)distance + " mts");
    }

    public void Distancia(){
        posicionInicial = distancia.transform.position;
        posicionObjeto = transform.position;
        heading = posicionInicial - posicionObjeto;
        distance = heading.magnitude;
        
    }

}
