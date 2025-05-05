using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // se serializa el enemigo para poder referenciarlo
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyDoublePrefab;
    [SerializeField] private GameObject enemyBossPrefab;
    [SerializeField] private float spawnDelay; //Tiempo de espera entre spawn
    [SerializeField] private int enemysUntilBoss; // Numero de enemigos a derrotar antes del boss
    
    // se crea un contador de los enemigos spawneados 
    private int enemiesSpawned;
    
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
            if (enemiesSpawned < enemysUntilBoss)
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
            
                // se espera x segundos entre spawns
                yield return new WaitForSeconds(spawnDelay);
                enemiesSpawned++;
            }
            else
            {
                yield return new WaitForSeconds(10f);
                Vector3 BossPotition = new Vector3(transform.position.x - 5, 0, 0);
                Instantiate(enemyBossPrefab, BossPotition, Quaternion.identity);
                break;
            }
            
        }
    }
}
