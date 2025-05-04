using System.Collections;
using UnityEngine;

public class EnemyDouble : MonoBehaviour
{
    [SerializeField] private float speed; // velocidad horizontal
    [SerializeField] private float amplitude; // Amplitud de oscilación vertial
    [SerializeField] private float frequency; // Velocidad con la que oscila
    [SerializeField] private float shootDelay; //Tiempo de espera entre disparos
    
    // prefab para referenciar el disparo que se va a instanciar
    [SerializeField] private GameObject disparoPrefab;
    // puntos donde aparecen los rayos laser
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnearDisparo());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(-1, 0, 0) * (Time.deltaTime * speed));
        // Se implementa movimiento oscilatorio con función seno
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 movement = new Vector3(-1, yOffset, 0).normalized * (speed * Time.deltaTime);
        transform.Translate(movement);
    }
    
    IEnumerator SpawnearDisparo()
    {
        while (true)
        {
            // se realiza instans del prefab de enemigo
            // se referencian ambos puntos de disparo
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            // se espera x segundos entre spawn de disparos
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
