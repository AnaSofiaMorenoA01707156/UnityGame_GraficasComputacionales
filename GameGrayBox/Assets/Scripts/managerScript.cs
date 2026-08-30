using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ManagerScript : MonoBehaviour
{
    public int clavos = 7;
    public static int clavados{get; private set;} //num de clavos clavados de vista pública
    public static Action cambioClavados; //cambia el num de clavos clavados y detona cambio del UI
    public static Action<bool> RetroFin; //detona muestra del texto de ganar/perder (WinLooseTextScript)
    private bool gameOver = false; //variable para exclusividad de win vs. loose
    void Awake()
    {
        clavados = 0;
    }
    public void OnEnable()
    {
        TimeManagerScript.cambioContador += RevisarTiempo; //se suscribe a cambioContador
    }
    public void OnDisable()
    {
        TimeManagerScript.cambioContador -= RevisarTiempo; //se desuscribe a cambioContador
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
        if (TablaLista) //cumple condición de ganar
        {
            Win();
        }
    }
    private void RevisarTiempo()
    {
        if (TimeManagerScript.segundos == 0) //el contador llegó a 0 (se acabó el tiempo)
        {
            if (TablaLista) //cumple condición de ganar
            {
                Win();
            }
            else //NO cumple condición de ganar
            {
                Lose();
            }
        }
    }

    public void Win()
    {
        if (gameOver) return;
        gameOver = true;
        TimeManagerScript timer = FindFirstObjectByType<TimeManagerScript>();
        Mallet mallet = FindFirstObjectByType<Mallet>();
        //detener movimiento y reacción de martillo
        mallet.StopAllCoroutines();
        mallet.enabled = false;
        //detener timemanager y su contador (UI)
        timer.enabled = false;
        //retro de ganar
        RetroFin?.Invoke(true);
    }

    public void Lose()
    {
        if (gameOver) return;
        gameOver = true;
        TimeManagerScript timer = FindFirstObjectByType<TimeManagerScript>();
        Mallet mallet = FindFirstObjectByType<Mallet>();
        //detener movimiento y reacción de martillo
        mallet.StopAllCoroutines();
        mallet.enabled = false;
        //detener timemanager y su contador (UI)
        timer.enabled = false;
        //retro de perder y volver a intentar
        RetroFin?.Invoke(false);
        Invoke("Reiniciar", 4f); //reiniciar el juego después de mostrar retroalimentación
    }

    void Reiniciar()
    { //reiniciar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
