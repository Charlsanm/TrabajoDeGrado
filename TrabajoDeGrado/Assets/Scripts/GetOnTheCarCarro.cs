using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetOnTheCarCarro : MonoBehaviour
{
    public GameObject text;
    public GameObject camPlayer;
    public GameObject camCar;
    private GameObject player;
    private GameObject car;
    private GetOutTheCarCarro scriptGetOutCarro;


    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        car = GameObject.FindGameObjectWithTag("Car2");
        scriptGetOutCarro = car.GetComponent<GetOutTheCarCarro>();

        GameObject.Find("police_car").GetComponent<CarController>().enabled = false;

        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == "Player")
        {
            if (Input.GetButton("Y"))
            {
                text.SetActive(false);
                camPlayer.SetActive(false);
                camCar.SetActive(true);
                //Destroy(player);
                player.SetActive(false);
                car.tag = "Player";
                GameObject.Find("police_car").GetComponent<CarController>().enabled = true;
                scriptGetOutCarro.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
