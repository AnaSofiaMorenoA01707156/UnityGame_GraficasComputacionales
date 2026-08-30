using UnityEngine;

public class PlankScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //si choca con el martillo sin que este ya haya chocado con algo más antes
        if (other.CompareTag("Mallet"))
        {
            Mallet mallet = Object.FindFirstObjectByType<Mallet>();
            if (!mallet.golpeResuelto)
            {
            mallet.golpeResuelto = true;
            mallet.RegresarArriba(); //manda al martillo a regresar a su posición inicial
            }
        }
    }
}
