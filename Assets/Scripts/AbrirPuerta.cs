using UnityEngine;
using System.Collections;

public class AbrirPuerta : MonoBehaviour
{
    public GameObject Puerta; // Referencia al Puerta que se reducirá de tamaño
    private bool colisionDetectada = false;
    private float tiempoDeAnimacion = 0.4f; // Duración de la animación en segundos
    private bool reduciendo = false;

    private Vector3 escalaInicial;
    private Vector3 pivotOffset;

    private void Start()
    {
        escalaInicial = Puerta.transform.localScale;
        pivotOffset = Puerta.transform.position + new Vector3(0, escalaInicial.y / 2, 0);
    }

    private void Update()
    {
        if (colisionDetectada && !reduciendo)
        {
            reduciendo = true;
            StartCoroutine(ReducirTamaño());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colisionDetectada = true;
        }
    }

    private IEnumerator ReducirTamaño()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / tiempoDeAnimacion;
            Vector3 nuevaEscala = escalaInicial;
            nuevaEscala.y = Mathf.Lerp(escalaInicial.y, 0, t);
            Puerta.transform.localScale = nuevaEscala;
            Puerta.transform.position = pivotOffset - new Vector3(0, nuevaEscala.y / 2, 0);
            yield return null;
        }
    }
}
