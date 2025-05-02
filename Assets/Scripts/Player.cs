using UnityEngine;

public class Player : MonoBehaviour
{
    // se serializa para poder ser modificada desde el editor de unity
    [SerializeField] private float speed;
    // se serializa la velocidad entre disparos
    [SerializeField] private float ratioDisparo;
    // prefab para referenciar el disparo que se va a instanciar
    [SerializeField] private GameObject disparoPrefab;
    // puntos donde aparecen los rayos laser
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    // se crea contador para llevar el tiempo
    private float temporizador = 0.5f;
    // vidas del jugador
    private float vidas = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Novimiento();
        DelimitarMovimiento();
        Disparar();
    }

    void Novimiento()
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
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            //cuando se realiza un disparo se reinicia el temporizador
            temporizador = 0;
        }
    }
    
    // el ontrigger del disparo es mas sencillo en quien recibe el disparo
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyLaser")||other.gameObject.CompareTag("Enemy"))
        {
            vidas -= 1;
            Destroy(other.gameObject);
            if (vidas <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
