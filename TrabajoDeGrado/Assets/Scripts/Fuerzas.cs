using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;



public class Fuerzas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tiempoText;
    public float tiempo = 0.0f;
    //public ThirdPersonCharacter m_Character;

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

            //m_Character.s
            //m_Character.Move(new Vector3(), false, false, true);

            tiempo += Time.deltaTime;
            tiempoText.SetText(tiempo.ToString("f0") + " seg");
        }
    }

}