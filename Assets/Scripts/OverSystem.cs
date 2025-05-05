using UnityEngine;
using UnityEngine.SceneManagement;

public class OverSystem : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
