using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fuerzas : MonoBehaviour
{

    public float force = 50f;

    public Animator animator;

    [SerializeField] TextMeshProUGUI tiempoText;
    public float tiempo = 0.0f;

/*
    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;
        if(body.tag == "caja"){
            //body.AddForce(transform.forward * 100f, ForceMode.Force);
            print("Moviendo");
        }
        print("No Moviendo");
    }
    */

    void Update(){
        bool crouch = Input.GetKey(KeyCode.Z);

        animator.SetBool("Empujar", crouch);
        
    }


    void OnTriggerStay(Collider other){

        Rigidbody body = other.GetComponent<Rigidbody>();

        if(other.tag == "caja"){
            //Vector3 direction = transform.forward;

            /*body.velocity = direction * 5;
            bool crouch = Input.GetKey(KeyCode.Z);

            animator.SetBool("Pushing", true);

            body.AddForce(transform.forward * force);
            print("Moviendo");
            */
            tiempo += Time.deltaTime;
            tiempoText.SetText(tiempo.ToString("f0") + " seg");
        }

        animator.SetBool("Pushing", false);
    }

}
