using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rejilla : MonoBehaviour
{
    public GameObject Puerta; // Referencia al Puerta que se reducirá de tamaño
    private bool puzzleCompletado = false;
    private float tiempoDeAnimacion = 0.4f; // Duración de la animación en segundos
    private bool reduciendo = false;
    private Vector3 escalaInicial;
    private Vector3 pivotOffset;

    public int botones_presionados = 0;

    void Start(){
        escalaInicial = Puerta.transform.localScale;
        pivotOffset = Puerta.transform.position + new Vector3(0, escalaInicial.y / 2, 0);
    }

    void Update()
    {
        if (puzzleCompletado && !reduciendo)
        {
            reduciendo = true;
            StartCoroutine(AbrirPuerta());
        }
    }

    public void sumar(){
        botones_presionados++;
        if(botones_presionados>=3){
            puzzleCompletado = true;
        }
    }

    public void restar(){
        botones_presionados--;
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

        Destroy(Puerta);
    }
}
