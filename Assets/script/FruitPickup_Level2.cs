using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPickup_Level2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("player"))
    {
        Debug.Log("Player menyentuh buah: " + gameObject.tag);

        FruitCollector_Level2 collector = other.GetComponent<FruitCollector_Level2>();
        if (collector == null) return;

        if (CompareTag("jeruk"))
        {
            Debug.Log("Menambahkan jeruk");
            collector.TambahJeruk();
        }
        else if (CompareTag("alpukat") || CompareTag("ceri") || CompareTag("pisang"))
        {
            Debug.Log("Buah salah! Mengurangi waktu.");
            collector.KurangiWaktu(5f);
        }

        Destroy(gameObject);
    }
}

}
