using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] lifes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lostLife(int indice)
    {
        lifes[indice].SetActive(false);
    }
}
