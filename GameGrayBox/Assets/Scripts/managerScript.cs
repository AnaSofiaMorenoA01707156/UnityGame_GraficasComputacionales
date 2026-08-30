using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ManagerScript : MonoBehaviour
{
    public int clavos = 2;
    public static int clavados{get; private set;}
    public static Action cambioClavados;
    private bool gameOver = false;
    void Awake()
    {
        clavados = 0;
    }
    public void OnEnable()
    {
        TimeManagerScript.cambioContador += revisarTiempo;
    }
    public void OnDisable()
    {
        TimeManagerScript.cambioContador -= revisarTiempo;
    }
    public bool TablaLista //si ya se han clavado todos los clavos (condición de ganar)
    {
        get { return clavados >= clavos; }
    }

    public void Clavar() //llamada por el clavo al ser martillado
    {
        if (gameOver) return;

        clavados++;
        cambioClavados?.Invoke();
        //mostrar retroalimentación (texto)
        if (TablaLista)
        {
            Win(); //cumple condición de ganar
        }
    }
    private void revisarTiempo()
    {
        if (TimeManagerScript.segundos == 0)
        {
            if (TablaLista)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
    }

    public void Win()
    {
        if (gameOver) return;
        gameOver = true;
        //retro de ganar
        Debug.Log("G");
    }

    public void Lose()
    {
        if (gameOver) return;
        gameOver = true;
        //retro de perder y volver a intentar
        Debug.Log("P");
        Invoke("Reiniciar", 4f); //reiniciar el juego después de mostrar retroalimentación
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
