using UnityEngine;

public class puzzle2 : MonoBehaviour
{
    
    public rejilla puerta;

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
        if ((other.CompareTag("Player") || other.CompareTag("caja")) && Boton_presionado == false && Boton_disponible == true)
        {
            ReducirAltura();
            Boton_presionado = true;
            puerta.sumar();
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
            puerta.restar();
        }
    }
}
