using UnityEngine;
using System;

public class TimeManagerScript : MonoBehaviour
{
    public static Action cambioContador; //cambia el contador y detona cambio del UI y en gamemanager
    public static int segundos{get; private set;} //num de segundos (contador) de vista pública
    private float segundoNormal = 1f; //disminuye como segundos de tiempo real
    private float decrementador;
    void Awake()
    {
        segundos = 20; //contador de 20 segundos
        decrementador = segundoNormal;
    }
    void Update()
    {
        decrementador -= Time.deltaTime; //verificar si pasó el segundo...
        if(decrementador <= 0 && segundos > 0) //..y si no ha llegado a 0 el contador
        {
            segundos--; //disminuir 1 segundo
            cambioContador?.Invoke(); //invocar cambio de UI y revisión de gamemanager
            decrementador = segundoNormal;
        }
    }
}
