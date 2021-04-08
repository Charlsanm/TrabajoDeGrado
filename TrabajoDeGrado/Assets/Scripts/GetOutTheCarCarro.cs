using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutTheCarCarro : MonoBehaviour
{
    public GameObject camPlayer;
    public GameObject camCar;
    public GameObject player;
    public GameObject respawn;
    private GameObject car;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject.Find("police_car").GetComponent<CarController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("X"))
            {
                camPlayer.SetActive(true);
                camCar.SetActive(false);
                //Instantiate(player, respawn.transform.position, respawn.transform.rotation);
                player.SetActive(true);
                this.gameObject.tag = "Car2";
                GameObject.Find("police_car").GetComponent<CarController>().enabled = false;
                this.enabled = false;
            }
    }
}
