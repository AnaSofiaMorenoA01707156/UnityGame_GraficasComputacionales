using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    public int clavos = 2;
    private int clavados = 0;
    private bool gameOver = false;

    public void TablaLista //si ya se han clavado todos los clavos (condición de ganar)
    {
        get { return clavados >= clavos; }
    }

    public void Clavar() //llamada por el clavo al ser martillado
    {
        if (gameOver) return;

        clavados++;
        //mostrar retroalimentación (texto)
        if (tablaLista)
        {
            Win(); //cumple condición de ganar
        }
    }

    public void Win()
    {
        if (gameOver) return;
        gameOver = true;
        //retro de ganar
    }

    public void Loose()
    {
        if (gameOver) return;
        gameOver = true;
        //retro de perder y volver a intentar
        Invoke("Reiniciar", 4f); //reiniciar el juego después de mostrar retroalimentación
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
