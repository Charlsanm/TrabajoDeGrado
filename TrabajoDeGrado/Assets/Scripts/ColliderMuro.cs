using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMuro : MonoBehaviour
{
    private Reloj reloj;

    // Start is called before the first frame update
    void Start()
    {
        reloj = FindObjectOfType<Reloj>();
        reloj.Pausar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Vehicle")){
            reloj.Continuar();
        }
    }
}
