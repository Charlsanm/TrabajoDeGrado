using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Empuje : MonoBehaviour
{
    public GameObject fuerza;
    public GameObject personajePeso;
    public GameObject cajaPeso;
    public GameObject caja;
    public GameObject player;
    public GameObject boton;
    public GameObject pantallaFinal;
    [SerializeField] TextMeshProUGUI velocidadCaja;
    [SerializeField] TextMeshProUGUI velocidadPlayer;

    [SerializeField] TextMeshProUGUI tiempoText;
    public float tiempo = 0.0f;
    private TMP_InputField fuerzaField;
    private TMP_InputField cajaMasa;
    private TMP_InputField personajeMasa;
    private Rigidbody rbCaja;
    private Rigidbody rbPlayer;
    private bool isRun;
    // Start is called before the first frame update
    void Start()
    {
        fuerzaField = fuerza.GetComponent<TMP_InputField>();
        cajaMasa = cajaPeso.GetComponent<TMP_InputField>();
        personajeMasa = personajePeso.GetComponent<TMP_InputField>();

        rbCaja = caja.GetComponent<Rigidbody>();
        rbPlayer = player.GetComponent<Rigidbody>();
        tiempoText.SetText("0 seg");
        isRun = false;
        Time.timeScale = 1;
        
        pantallaFinal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(isRun){
            tiempo += Time.deltaTime;
            tiempoText.SetText(tiempo.ToString("f0") + " seg");
        }

    }

    private void FixedUpdate()
    {
        velocidadCaja.SetText("VELOCIDAD: " + Math.Round(rbCaja.velocity.magnitude, 3) + " m/s");
        velocidadPlayer.SetText("VELOCIDAD: " + Math.Round(rbPlayer.velocity.magnitude, 3) + " m/s");
    }

    public void Comenzar(){

        print(cajaMasa.text);
        print(personajeMasa.text);
        print(fuerzaField.text);

        rbCaja.mass = (float) double.Parse(cajaMasa.text);
        rbPlayer.mass = (float) double.Parse(personajeMasa.text);

        float fuerza = (float) double.Parse(fuerzaField.text);

        //Caja
        rbCaja.AddForce(Vector3.right * fuerza, ForceMode.Impulse);

        //Personaje
        rbPlayer.AddForce(Vector3.left * fuerza, ForceMode.Impulse);

        isRun = true;

        
        boton.SetActive(false);
    }
}
