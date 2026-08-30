using UnityEngine;

public class NailScript : MonoBehaviour
{
    private bool golpeado = false;
    public float clavadoAbajo = -0.2;
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
        if (other.CompareTag("Mallet") && !mallet.golpeResuelto)
        {
            if (!golpeado) //si no ha sido golpeado
            {
                golpeado = true; //ya fue golpeado
                transform.position = transform.position + new Vector3(0f, clavadoAbajo, 0f); //se baja para mostrarse clavado
                //GameManager manager = Object.FindFirstObjectByType<GameManager>();
                //if (manager != null) manager.Nailed();
            }
            Mallet mallet = Object.FindFirstObjectByType<Mallet>();
            mallet.golpeResuelto = true;
            mallet.RegresarArriba(); //manda al martillo a regresar a su posición inicial
        }
    }
}
