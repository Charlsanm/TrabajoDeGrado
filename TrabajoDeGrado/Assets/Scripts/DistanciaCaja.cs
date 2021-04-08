using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanciaCaja : MonoBehaviour
{
    public GameObject rampa;
    private Vector3 posicionRampa;
    private Vector3 posicionCaja;
    private Vector3 heading;
    private float distance;
    [SerializeField] TextMeshProUGUI textDistancia;
    void Start()
    {
       posicionRampa = rampa.transform.position;
       posicionCaja = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Distancia();
        textDistancia.SetText("Distancia: " + (int)distance + " mts");
    }

    public void Distancia(){
        posicionRampa = rampa.transform.position;
        posicionCaja = transform.position;
        heading = posicionRampa - posicionCaja;
        distance = heading.magnitude;
        
    }
}
