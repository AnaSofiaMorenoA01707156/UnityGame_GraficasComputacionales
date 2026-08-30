using UnityEngine;
using TMPro;

public class NailedCountScript : MonoBehaviour
{
    public TextMeshProUGUI Count;
    public void OnEnable()
    {
        ManagerScript.cambioClavados += ActualizarContador;
    }
    public void OnDisable()
    {
        ManagerScript.cambioClavados += ActualizarContador;
    }
    private void ActualizarContador()
    {
        Count.text = $"{ManagerScript.clavados.ToString("0")}/2";
    }
}
