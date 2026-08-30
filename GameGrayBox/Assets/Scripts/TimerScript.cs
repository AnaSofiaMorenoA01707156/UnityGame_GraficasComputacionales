using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
   public TextMeshProUGUI Timer;
    public void OnEnable()
    {
        TimeManagerScript.cambioContador += ActualizarTiempo; //se suscribe a cambioContador
    }
    public void OnDisable()
    {
        TimeManagerScript.cambioContador -= ActualizarTiempo; //se desuscribe a cambioContador
    }
    private void ActualizarTiempo()
    { //actualiza el texto con el num de segundos restantes (contador)
        Timer.text = $"00:{TimeManagerScript.segundos.ToString("00")}";
    }
}
