using UnityEngine;
using UnityEngine.SceneManagement;
public class jugar : MonoBehaviour
{

    public void CambiarEscena(string name)
    {
        SceneManager.LoadScene(name);
    }
}
