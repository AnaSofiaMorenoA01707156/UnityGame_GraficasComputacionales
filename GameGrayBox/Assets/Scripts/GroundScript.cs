using UnityEngine;

public class GroundScript : MonoBehaviour
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
        //si choca con el martillo
        if (other.CompareTag("Mallet"))
        {
            Mallet mallet = Object.FindFirstObjectByType<Mallet>();
            if (!mallet.golpeResuelto) //el martillo no ha chocado con algo más antes en esa bajada
            {
            mallet.golpeResuelto = true;
            mallet.RegresarArriba(); //manda al martillo a regresar a su posición inicial
            }
        }
    }
}
