using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    [SerializeField] private float anchoImagen;
    
    private Vector3 posicionInicial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // se calcula el residuo de la division
        // cuando se cumpla un ciclo la division no tendra residuo
        float resto = (velocidad * Time.time) % anchoImagen;
        // actualizacion de posicion de background
        // cuando resto sea cero vuelve a la posicion inicial
        transform.position = posicionInicial + direccion * resto;
        
    }
}
