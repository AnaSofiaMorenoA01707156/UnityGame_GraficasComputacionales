using UnityEngine;

public class Mallet : MonoBehaviour
{

    public float velocidad = 9f;   // qué tan rápido se desplaza
    public float alcance = 5f;     // cuántas unidades se aleja del centro

    private Vector3 origen;
    private Rigidbody rb;
    private bool matrillando = false;
    public float caida = -30f;
    public bool golpeResuelto = false; //evita que si ya golpeó el clavo reaccione si golpea después la tabla o piso


    void Start()
    {
        origen = transform.position; //registrar posición inicial
    }

    void Update()
    {
        if (!matrillando) //movimiento continuo de lado a lado mientras no matrille
        {
            float desfase = Mathf.PingPong(Time.time * velocidad, alcance * 2f) - alcance;
            transform.position = origen + new Vector3(desfase, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (!matrillando)){ //si no está ya matrillando reacciona al input
            Martillar();
        }
    }

    public void Martillar()
    {
        matrillando = true;
        golpeResuelto = false;
        transform.position = transform.position + new Vector3(0f, caida, 0f); //baja para martillar
    }

    public void RegresarArriba()
    { //regresa a su posición de origen y ya puede volver a reaccionar a input (matrillar)
        transform.position = origen;
        matrillando = false;
    }
}
