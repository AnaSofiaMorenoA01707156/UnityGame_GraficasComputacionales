using UnityEngine;

public class NailScript : MonoBehaviour
{
    private bool golpeado = false;
    public float clavadoAbajo = -0.2f;
    public ParticleSystem particulas; //obtener objeto con sistema de partículas vinculado a cada clavo
    private AudioSource golpe;
    void Start()
    {
        golpe = GetComponent<AudioSource>(); //obtener componente propio de audiosource con el sonido de golpe
    }
    void OnTriggerEnter(Collider other)
    {
        //si choca con el martillo
        if (other.CompareTag("Mallet"))
        {
            Mallet mallet = Object.FindFirstObjectByType<Mallet>();
            if (!mallet.golpeResuelto){ //el martillo no ha chocado con algo más antes en esa bajada
                if (!golpeado) //si no ha sido golpeado
                {
                    golpeado = true; //ya fue golpeado
                    particulas.Play(); //ejecutar sistema de partículas al momento de impacto del clavo
                    golpe.Play();
                    transform.position = transform.position + new Vector3(0f, clavadoAbajo, 0f); //se baja para mostrarse clavado
                    ManagerScript manager = Object.FindFirstObjectByType<ManagerScript>();
                    if (manager != null) manager.Clavar();
                }
                mallet.golpeResuelto = true;
                mallet.RegresarArriba(); //manda al martillo a regresar a su posición inicial
            }
        }
    }
}
