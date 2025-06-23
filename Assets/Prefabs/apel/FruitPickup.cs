using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            FruitCollector collector = other.GetComponent<FruitCollector>();

            if (collector == null) return;

            if (gameObject.CompareTag("apel"))
            {
                collector.TambahApel();
            }
            else if (gameObject.CompareTag("delima") || gameObject.CompareTag("jambu"))
            {
                collector.KurangiWaktu(5f); // Kurangi waktu 5 detik
            }

            Destroy(gameObject); // Buah menghilang setelah disentuh
        }
    }
}
