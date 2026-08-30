using UnityEngine;
using TMPro;

public class WinLooseTextScript : MonoBehaviour
{
    public TextMeshProUGUI TextoFin;
    public void OnEnable()
    {
        ManagerScript.RetroFin += MostrarTextoFin; //se suscribe a RetroFin
    }
    public void OnDisable()
    {
        ManagerScript.RetroFin -= MostrarTextoFin; //se desuscribe a RetroFin
    }
    private void MostrarTextoFin(bool win)
    { //actualiza el texto dependiendo si el jugador ganó o no
        if (win)
        {
             TextoFin.text = $"You Win!";
        }
        else
        {
            TextoFin.text = $"You lost! Trying again in 3 s...";
        }
    }
}
