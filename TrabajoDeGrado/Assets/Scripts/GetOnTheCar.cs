using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetOnTheCar : MonoBehaviour
{
    public GameObject text;
    public GameObject camPlayer;
    public GameObject camCar;
    private GameObject player;
    private GameObject car;
    private GetOutTheCar scriptGetOut;


    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        car = GameObject.FindGameObjectWithTag("Car");
        scriptGetOut = car.GetComponent<GetOutTheCar>();

        GameObject.Find("firetruck").GetComponent<CarController>().enabled = true;

        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate(){
       
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
                GameObject.Find("firetruck").GetComponent<CarController>().enabled = true;
                scriptGetOut.enabled = true;
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
