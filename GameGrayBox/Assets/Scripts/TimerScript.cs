using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
   public TextMeshProUGUI Timer;
    public void OnEnable()
    {
        TimeManagerScript.cambioContador += ActualizarTiempo;
    }
    public void OnDisable()
    {
        TimeManagerScript.cambioContador -= ActualizarTiempo;
    }
    private void ActualizarTiempo()
    {
        Timer.text = $"00:{TimeManagerScript.segundos.ToString("00")}";
    }
}
