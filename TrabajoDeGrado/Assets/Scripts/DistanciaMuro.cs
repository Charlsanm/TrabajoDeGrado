using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanciaMuro : MonoBehaviour
{
    public GameObject isla;
    private Vector3 posicionIsla;
    private Vector3 posicionMuro;
    private Vector3 heading;
    private float distance;
    [SerializeField] TextMeshProUGUI textDistancia;

    // Start is called before the first frame update
    void Start()
    {
       posicionIsla = isla.transform.position;
       posicionMuro = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Distancia();
        textDistancia.SetText("Distancia entre Muro - Isla: " + (int)distance + " m");
    }

    public void Distancia(){
        heading = posicionIsla - posicionMuro;
        distance = heading.magnitude;
        
    }
}
