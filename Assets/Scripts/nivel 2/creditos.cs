using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos: MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene("creditos");
		}
	}
}
