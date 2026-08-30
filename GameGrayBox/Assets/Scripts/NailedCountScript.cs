using UnityEngine;
using TMPro;

public class NailedCountScript : MonoBehaviour
{
    public TextMeshProUGUI Count;
    public void OnEnable()
    {
        ManagerScript.cambioClavados += ActualizarContador; //se suscribe a cambioClavados
    }
    public void OnDisable()
    {
        ManagerScript.cambioClavados += ActualizarContador; //se desuscribe a cambioClavados
    }
    private void ActualizarContador()
    {//actualiza el texto con el num de clavos ya clavados
        Count.text = $"{ManagerScript.clavados.ToString("0")}/7";
    }
}
