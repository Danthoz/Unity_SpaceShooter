using System;
using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    // Se serializa la velocidad que tendrá el disparo
    [SerializeField] private float speed;
    [SerializeField] private float amplitude; // Amplitud de oscilación vertial
    [SerializeField] private float frequency;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Se implementa movimiento oscilatorio con función seno
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 movement = new Vector3(-1 * speed, yOffset, 0).normalized * (speed * Time.deltaTime);
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CleanningZone"))
        {
            Destroy(gameObject);
        }
    }
}
