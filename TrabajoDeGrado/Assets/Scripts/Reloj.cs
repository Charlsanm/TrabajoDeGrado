using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo incial en Segundos")]
    public int initialTime;

    [Tooltip("Escala del tiempo del reloj")]
    [Range(-10.0f, 10.0f)]
    public float timeScale = 1;

    private Text myText;
    private float tiempoFrameConTimeScale = 0f;
    private float timeInSecondsToShow = 0f;
    private float timeScaleWhenPaused, initialTimeScale;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //Establecer la escala de tiempo original
        initialTimeScale = timeScale;
        
        //Obtiene el componente del texto
        myText = GetComponent<Text>();

        //Inicializar la variable que acumula los tiempos en cada frame con el tiempo inicial
        timeInSecondsToShow = initialTime;

        ActualizarReloj(initialTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            //La siguiente variable representa el tiempo de cada frame onsiderando la escala de tiempo
            tiempoFrameConTimeScale = Time.deltaTime * timeScale;

            //Acumla el tiempo transcurrido para luego mostrarlo en el reloj.
            timeInSecondsToShow += tiempoFrameConTimeScale;
            ActualizarReloj(timeInSecondsToShow);
        }
    }

    void ActualizarReloj(float tiempoEnSegundos){
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        //Asegurar que el tiempo no sea Negativo
        if (tiempoEnSegundos < 0)
        {
            tiempoEnSegundos = 0;
        }

        //Calcular minutos y segundos
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        //Crear la cadena de caracteres con dos digitos para los segundo y minutos
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        //Actualizar el elemento Text de la interfaz con la cadena de caracteres
        myText.text =  textoDelReloj;
    }

    public void Pausar(){
        if (!isPaused)
        {
            isPaused = true;
            timeScaleWhenPaused =timeScale;
            timeScale = 0;
        }
    }

    public void Continuar(){
        if (isPaused)
        {
            isPaused = false;
            timeScale = timeScaleWhenPaused;
        }
    }

    public void ResetTimer(){
        isPaused = true;
        timeScale = initialTimeScale;
        timeInSecondsToShow = initialTime;
        ActualizarReloj(timeInSecondsToShow);
    }
}
