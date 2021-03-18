using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarMasa(int opcion){
        Debug.Log("Parametro " + opcion);
        switch(opcion){
            case 0:
                Debug.Log("Opcion 1");
                rb.mass = 10f;
                break;
            case 1:
                Debug.Log("Opcion 2");
                rb.mass = 50f;
                break;
            case 2:
                Debug.Log("Opcion 3");
                rb.mass = 100f;
                break;
        }
        
    }
}
