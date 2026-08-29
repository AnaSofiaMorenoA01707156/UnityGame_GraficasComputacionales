using UnityEngine;

public class Mallet : MonoBehaviour
{

    public float velocidad = 9f;   // qué tan rápido se desplaza
    public float alcance = 5f;     // cuántas unidades se aleja del centro

    private Vector3 origen;
    private Rigidbody rb;
    private bool cayendo = false;


    void Start()
    {
        origen = transform.position;

    }

    void Update()
    {
        if (!cayendo)
        {
            float desfase = Mathf.PingPong(Time.time * velocidad, alcance * 2f) - alcance;
            transform.position = origen + new Vector3(desfase, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            Martillar();
        }
    }

    public void Martillar()
    {
        cayendo = true;
        float downfall = -10f;
        transform.position = transform.position + new Vector3(0f, downfall, 0f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plano"))
        {
            Debug.Log("Perdiste");
        }
    }
}
