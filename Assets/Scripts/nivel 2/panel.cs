using UnityEngine;

public class panel : MonoBehaviour
{
    public GameObject caja;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Activa la gravedad en el objeto
            caja.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
