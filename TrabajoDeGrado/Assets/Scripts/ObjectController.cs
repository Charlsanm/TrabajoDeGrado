using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectController : MonoBehaviour
{
    private Reloj reloj;
    public GameObject pantallaFin;

    // Start is called before the first frame update
    void Start()
    {
        pantallaFin.SetActive(false);
        reloj = FindObjectOfType<Reloj>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "isla" ){
            reloj.Pausar();
            StartCoroutine("MostrarPantallaFinal");
        }else if(collision.gameObject.tag == "Agua"){
            StartCoroutine("ReiniciarNivel");
        }
        
    }

    IEnumerator ReiniciarNivel(){
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync("1ley_1.0");
    }

    IEnumerator MostrarPantallaFinal(){
        yield return new WaitForSeconds(1.5f);
        pantallaFin.SetActive(true);
    }
}
