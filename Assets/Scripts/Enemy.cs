using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject disparoPrefab; // prefab para referenciar el disparo que se va a instanciar 
    [SerializeField] private GameObject spawnPoint; // puntos donde aparecen los rayos laser
    [SerializeField] private float shootDelay; //Tiempo de espera entre disparos
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnearDisparo());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * (Time.deltaTime * speed));
    }
    
    IEnumerator SpawnearDisparo()
    {
        while (true)
        {
            // se realiza instans del prefab de enemigo
            Instantiate(disparoPrefab, spawnPoint.transform.position, Quaternion.identity);
            // se espera X segundos entre spawn de disparos
            yield return new WaitForSeconds(shootDelay);
        }
    }
   
    // el ontrigger del disparo es mas sencillo en quien recibe el disparo
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        // se destruye al chocar con la zona de limpieza
        if (other.gameObject.CompareTag("CleanningZone"))
        {
            Destroy(gameObject);
        }
    }
}
