using UnityEngine;
using System;

public class TimeManagerScript : MonoBehaviour
{
    public static Action cambioContador;
    public static int segundos{get; private set;}
    private float segundoNormal = 1f;
    private float decrementador;
    void Awake()
    {
        segundos = 30;
        decrementador = segundoNormal;
    }
    void Update()
    {
        decrementador -= Time.deltaTime;

        if(decrementador <= 0 && segundos > 0)
        {
            segundos--;
            cambioContador?.Invoke();
            decrementador = segundoNormal;
        }
    }
}
