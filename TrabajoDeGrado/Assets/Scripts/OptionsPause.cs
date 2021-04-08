using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private InputField fuerzaField;
    private Dropdown dropdown;
    private Rigidbody rbCaja;
    private Rigidbody rbPlayer;
    
    private void Start(){
        pressF.SetActive(false);
        fuerza.SetActive(false);
        masa.SetActive(false);
        boton.SetActive(false);
        fuerzaField = fuerza.GetComponent<InputField>();
        dropdown = masa.GetComponent<Dropdown>();
        rbCaja = caja.GetComponent<Rigidbody>();
        rbPlayer = player.GetComponent<Rigidbody>();
        fuerzaPlayer.SetText("Fuerza: " + rbPlayer.mass + " N");
        masaCaja.SetText("Masa Caja: " + rbCaja.mass + " N");
    }
    void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            pressF.SetActive(true);
            bool options = Input.GetKey(KeyCode.F);
            if(options){
                Time.timeScale = 0f;
                fuerza.SetActive(true);
                masa.SetActive(true);
                boton.SetActive(true);
            }else{
                Time.timeScale = 1;
            }

        }        
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            pressF.SetActive(false);
            fuerza.SetActive(false);
            masa.SetActive(false);
        }
    }

    public void Cerrar(){
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
        rbPlayer.mass = float.Parse(fuerzaField.text, System.Globalization.CultureInfo.InvariantCulture);
        print(rbPlayer.mass);

        fuerzaPlayer.SetText("Fuerza: " + rbPlayer.mass + " N");
        masaCaja.SetText("Masa Caja: " + rbCaja.mass + " Kg");

        fuerza.SetActive(false);
        masa.SetActive(false);
        boton.SetActive(false);
    }
}
