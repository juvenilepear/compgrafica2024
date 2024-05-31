using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompletado : MonoBehaviour
{
    public GameObject Puerta; // Referencia al Puerta que se reducirá de tamaño
    private bool puzzleCompletado = false;
    private float tiempoDeAnimacion = 0.4f; // Duración de la animación en segundos
    private bool reduciendo = false;
    private Vector3 escalaInicial;
    private Vector3 pivotOffset;

    public List<int> ordenBotones = new List<int>();
    private int currentIndex = 0;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escalaInicial = Puerta.transform.localScale;
        pivotOffset = Puerta.transform.position + new Vector3(0, escalaInicial.y / 2, 0);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleCompletado && !reduciendo)
        {
            reduciendo = true;
            audioSource.Play();
            StartCoroutine(AbrirPuerta());
        }
    }

    public void VerificarOrden(int botonPresionado)
    {
        if (botonPresionado == ordenBotones[currentIndex])
        {
            currentIndex++;
            if (currentIndex == ordenBotones.Count)
            {
                puzzleCompletado = true;;
                currentIndex = 0; // Reinicia el índice para la próxima secuencia
            }
        }
        else
        {
            currentIndex = 0; // Error en la secuencia, reinicia el índice
        }
    }

    private IEnumerator AbrirPuerta()
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
