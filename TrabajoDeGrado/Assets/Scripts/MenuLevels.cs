using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarLey1(){
        SceneManager.LoadScene("1ley_1.0");
    }
    public void CargarLey2(){
        SceneManager.LoadScene("2ley");
    }
    public void CargarLey3(){
        SceneManager.LoadScene("3ley");
    }
}
