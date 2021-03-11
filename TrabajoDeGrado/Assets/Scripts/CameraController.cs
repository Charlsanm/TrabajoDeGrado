using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variables
    public GameObject player;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = obtiene la posicion de la camara o el objeeto
        offset = transform.position - player.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() 
    {
        transform.position = player.transform.position + offset;
    }
}
