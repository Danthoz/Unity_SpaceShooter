using System;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    // Se serializa la velocidad que tendrá el disparo
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (Time.deltaTime * speed)); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CleanningZone"))
        {
            Destroy(gameObject);
        }
    }
}
