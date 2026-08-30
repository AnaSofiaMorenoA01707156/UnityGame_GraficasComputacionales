using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{

    public float velocidad = 9f;   // qué tan rápido se desplaza lado a lado
    public float alcance = 5f;     // cuántas unidades se aleja del centro

    private Vector3 origen;
    private Rigidbody rb;
    private bool matrillando = false; //evita que reaccione a un segundo input antes de volver a subir
    public float caida = -30f;
    public bool golpeResuelto = false; //evita que si ya golpeó el clavo reaccione si golpea después la tabla o piso


    void Start()
    {
        origen = transform.position; //registrar posición inicial
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!matrillando) //movimiento continuo de lado a lado mientras no matrille
        {
            float desfase = Mathf.PingPong(Time.time * velocidad, alcance * 2f) - alcance; //obtener desfase
            transform.position = origen + new Vector3(desfase, 0f, 0f); //movimiento con desfase
        }

        if (Input.GetKeyDown(KeyCode.Space) && (!matrillando)){ //si no está ya matrillando reacciona al input
            Martillar();
        }
    }

    public void Martillar()
    {
        matrillando = true; //ya está martillando, no acepta otro input hasta subir
        golpeResuelto = false; //aún no ha golpeado con algo
        StartCoroutine(MovimientoMartillar()); //corrutina para bajar y martillar
    }

    public void RegresarArriba()
    { //regresa a su posición de origen y ya puede volver a reaccionar a input (matrillar)
        transform.position = origen;
        matrillando = false;
    }

    //corrutina para martillar (bajar), usando movimiento de rigidbody con tiempo de física
    private IEnumerator MovimientoMartillar()
    {
        Vector3 posActual = transform.position;
        Vector3 destino = posActual + new Vector3(0f, caida, 0f); //final de la caída

        float contador = 0f;
        float tiempoMovimiento = 0.2f; //tiempo para caer
        //mientras siga el tiempo de caída y no haya golpeado nada aún
        while(contador < tiempoMovimiento && !golpeResuelto){
            //mover con física de rigidbody
            rb.MovePosition(Vector3.Lerp(posActual,destino,contador/tiempoMovimiento));
            contador += Time.fixedDeltaTime; //usar tiempo de física de Unity
            yield return new WaitForFixedUpdate();
        }
        if (!golpeResuelto) //si no chocó con nada, aún así regresa arriba
        {
            RegresarArriba();
        }
    }
}
