using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CronometroCaja : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tiempoText;
    public float tiempo = 0.0f;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        tiempoText.SetText(tiempo.ToString("f0"));
    }
}
