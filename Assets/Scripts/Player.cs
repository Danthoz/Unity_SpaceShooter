using System;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed; // Velocidad de movimiento
    [SerializeField] private float ratioDisparo; // Velocidad entre disparos
    [SerializeField] private Disparo disparoPrefab; // prefab del disparo que se va a instanciar
    // puntos donde aparecen los rayos laser
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private TextMeshProUGUI scoreText; //Se serializa la puntuación
    private float temporizador = 0.5f; // se crea contador para llevar el tiempo
    private int vidas = 3; // variable de vidas del jugador
    private float score = 0f; // variable para la puntuación del juego
    public HUD hud;
    private ObjectPool<Disparo> pool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        pool = new ObjectPool<Disparo>(CreateDisparo, OnGetDisparo, OnReleaseDisparo);
    }

    // Metodo para crear balas cuando no hayan en el pool
    private Disparo CreateDisparo()
    {
        Disparo disparo = Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
        disparo.MyPool = pool; // se le indica al disparo la pool a la que pertenece
        return disparo;
    }
    
    // Metodo para reciclar bala existente del pool
    private void OnGetDisparo(Disparo disparo)
    {
        disparo.gameObject.SetActive(true); // se activa el objeto del pool
    }
    
    // Metodo para devolver una bala al pool
    private void OnReleaseDisparo(Disparo disparo)
    {
        disparo.gameObject.SetActive(false); // se desactiva el objeto.
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
        Disparar();
        UpdateScore();
    }

    void Movimiento()
    {
        // se toma el valor de movimiento en la entrada de manera Vertical
        float inputV = Input.GetAxisRaw("Vertical");
        float inputH = Input.GetAxisRaw("Horizontal");
        // se acutaliza la posición con el valor de entrada recibido
        transform.Translate(new Vector2(inputH, inputV).normalized * (speed * Time.deltaTime));
    }

    void DelimitarMovimiento()
    {
        // Permite delimitar un valor entre un minimo y un máximo
        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        // se actualiza posicion delimitada
        transform.position = new Vector3(xClamped, yClamped, transform.position.z);
    }

    void Disparar()
    {
        //se va aumentando el tiempo del temporizador
        temporizador += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)&& temporizador > ratioDisparo)
        {
            //Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            //Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            pool.Get().transform.position = spawnPoint1.transform.position;
            pool.Get().transform.position = spawnPoint2.transform.position;
            //cuando se realiza un disparo se reinicia el temporizador
            temporizador = 0;
        }
    }
    
    // el ontrigger del disparo es mas sencillo en quien recibe el disparo
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLaser")||other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            if (vidas <= 1)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                vidas -= 1;
                hud.lostLife(vidas);
            }
        }
    }
    
    void UpdateScore()
    {
        score = score + 0.01f ;
        scoreText.text = "Score: " + (int) score;
    }
}
