using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // se serializa el enemigo para poder referenciarlo
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyDoublePrefab;
    
    [SerializeField] private float spawnDelay; //Tiempo de espera entre spawn
    
    // se crea un contador de los enemigos spawneados 
    int enemiesSpawned;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnearEnemys());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // se crea una corrutina para spawnear enemigos
    IEnumerator SpawnearEnemys()
    {
        while (true)
        {
            // se crea la posicion aleatoria en Y, para instanciar enemigos
            Vector3 RandomPotition = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), 0);

            if (enemiesSpawned%2 == 0)
            {
                // se realiza instans del prefab de enemigo
                Instantiate(enemyPrefab, RandomPotition, Quaternion.identity);
            }
            else
            {
                // se realiza instans del prefab de enemigo
                Instantiate(enemyDoublePrefab, RandomPotition, Quaternion.identity);
            }
            
            // se espera 1 segundo entre spawns
            yield return new WaitForSeconds(spawnDelay);
            enemiesSpawned++;
        }
    }
}
