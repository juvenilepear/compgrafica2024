using UnityEngine;

public class boton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ReducirAltura()
    {
            Vector3 nuevaEscala = cilindro.transform.localScale;
            nuevaEscala.y /= 5f;
            cilindro.transform.localScale = nuevaEscala;
            Boton_presionado = true;
    }

    private void RestaurarAltura()
    {
        Vector3 nuevaEscala = cilindro.transform.localScale;
        nuevaEscala.y *= 5f; // Altura original
        cilindro.transform.localScale = nuevaEscala;
        Boton_presionado = false;
    }

    private void Habilitar_boton()
    {
        Boton_disponible = true;
    }

    public bool Boton_presionado = false;
    public bool Boton_disponible = true;
    public GameObject cilindro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Boton_presionado == false && Boton_disponible == true)
        {
            ReducirAltura();
            Boton_presionado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && Boton_presionado == true)
        {
            RestaurarAltura();
            Boton_disponible = false;
            Invoke(nameof(Habilitar_boton), 0.2f);
            Boton_presionado = false;
        }
    }
}
