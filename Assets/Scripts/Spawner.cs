using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // se serializa el enemigo para poder referenciarlo
    [SerializeField] private GameObject enemyPrefab;
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
            // se realiza instans del prefab de enemigo
            Instantiate(enemyPrefab, RandomPotition, Quaternion.identity);
            // se espera 1 segundo entre spawns
            yield return new WaitForSeconds(2f);    
        }
    }
}
