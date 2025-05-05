using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSystem : MonoBehaviour
{

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
