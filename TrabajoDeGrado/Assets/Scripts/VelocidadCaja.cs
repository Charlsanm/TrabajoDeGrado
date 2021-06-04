using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class VelocidadCaja : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI velocidad;
    private Rigidbody rbCaja;

    private void Start(){
        rbCaja = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //velocidad.SetText("Velocidad: " + Mathf.RoundToInt(rbCaja.velocity.magnitude) + " m/s2");
        velocidad.SetText("Aceleración: " + Math.Round(rbCaja.velocity.magnitude, 1) + " m/s");
    }
}
