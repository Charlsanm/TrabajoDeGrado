using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OptionsPause : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI fuerzaPlayer;
    [SerializeField] TextMeshProUGUI masaCaja;
    public GameObject pressF;
    public GameObject fuerza;
    public GameObject masa;
    public GameObject boton;
    public GameObject caja;
    public GameObject player;

    public GameObject canvas;
    public GameObject canvasPrincipal;
    private InputField fuerzaField;
    private Dropdown dropdown;
    private Rigidbody rbCaja;
    private Rigidbody rbPlayer;
    
    private void Start(){
        pressF.SetActive(false);
        //fuerza.SetActive(false);
        //masa.SetActive(false);
        //boton.SetActive(false);
        canvas.SetActive(false);
        canvasPrincipal.SetActive(true);
        fuerzaField = fuerza.GetComponent<InputField>();
        dropdown = masa.GetComponent<Dropdown>();
        rbCaja = caja.GetComponent<Rigidbody>();
        rbPlayer = player.GetComponent<Rigidbody>();
        fuerzaPlayer.SetText("Fuerza: 0 N");
        masaCaja.SetText("Masa Caja: " + rbCaja.mass + " Kg");
    }
    void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            pressF.SetActive(true);
            bool options = Input.GetKey(KeyCode.F);
            if(options){
                Time.timeScale = 0f;
                canvas.SetActive(true);
                canvasPrincipal.SetActive(false);
                //fuerza.SetActive(true);
                //masa.SetActive(true);
                //boton.SetActive(true);
            }else{
                Time.timeScale = 1;
            }

        }        
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            pressF.SetActive(false);
        }
    }

    public void Cerrar(){
        //Quitar pausa
        Time.timeScale = 1;
        print(dropdown.value); //Devuelve la posicion seleccionada
        print(fuerzaField.text);
        
        //Cambiar masa en la caja
        switch(dropdown.value){
            case 0:
                rbCaja.mass = 10f;
                break;
            case 1:
                rbCaja.mass = 50f;
                break;
            case 2:
                rbCaja.mass = 100f;
                break;
        }

        //Cambiar fuerza
        double num = Math.Round(double.Parse(fuerzaField.text, System.Globalization.CultureInfo.InvariantCulture));
        double mass = (num*2)/24;
        rbPlayer.mass = (float)mass;

        fuerzaPlayer.SetText("Fuerza: " + num + " N");
        masaCaja.SetText("Masa Caja: " + rbCaja.mass + " Kg");

        canvas.SetActive(false);
        canvasPrincipal.SetActive(true);

        //fuerza.SetActive(false);
        //masa.SetActive(false);
        //boton.SetActive(false);
    }
}
