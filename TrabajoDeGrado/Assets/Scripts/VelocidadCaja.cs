using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VelocidadCaja : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI velocidad;
    private Rigidbody rbCaja;

    private void Start(){
        rbCaja = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocidad.SetText("Velocidad: " + Mathf.RoundToInt(rbCaja.velocity.magnitude) + " m/s2");
    }
}
