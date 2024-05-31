using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text textObject; // Asigna el objeto de texto en el inspector
    public float displayDuration = 6f; // Duración en segundos

    private float timer = 0f;

    private void Start()
    {
        // Inicializa el temporizador
        timer = displayDuration;
    }

    private void Update()
    {
        // Actualiza el temporizador
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Desactiva el objeto de texto cuando se agota el tiempo
            textObject.gameObject.SetActive(false);
        }
    }
}
