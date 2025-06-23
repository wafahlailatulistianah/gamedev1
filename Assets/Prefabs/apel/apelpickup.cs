using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apelpickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            other.GetComponent<FruitCollector>().TambahApel(); // tambah angka apel
            Destroy(gameObject); // hilangkan apel
        }
    }
}
