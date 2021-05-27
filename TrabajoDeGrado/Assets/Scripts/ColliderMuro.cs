using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderMuro : MonoBehaviour
{
    private Reloj reloj;
    [SerializeField] TextMeshProUGUI velocidadImpacto;
    private float speed;
    private GameObject carro;

    private Rigidbody rbcarro;

    // Start is called before the first frame update
    void Start()
    {
        carro = GameObject.FindWithTag("Vehicle");
        rbcarro = carro.GetComponent<Rigidbody>();
        reloj = FindObjectOfType<Reloj>();
        reloj.Pausar();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.RoundToInt(rbcarro.velocity.magnitude * 3600 / 1000);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Vehicle")){
            reloj.Continuar();
            velocidadImpacto.SetText("Velocidad Impacto: " + speed + " km/h");
        }
    }
}
