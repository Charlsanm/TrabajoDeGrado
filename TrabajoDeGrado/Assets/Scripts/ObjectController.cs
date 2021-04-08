﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Reloj reloj;

    // Start is called before the first frame update
    void Start()
    {
        reloj = FindObjectOfType<Reloj>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "isla" ){
            reloj.Pausar();
        }
    }
}
