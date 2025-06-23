using System.Collections;
using UnityEngine;

public class FruitPickup_Level3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            FruitCollector_Level3 collector = other.GetComponent<FruitCollector_Level3>();
            if (collector == null) return;

            if (CompareTag("stroberry"))
            {
                collector.TambahStrawberry();
            }
            else if (CompareTag("pir") ||  CompareTag("anggur"))
            {
                collector.KurangiWaktu(5f);
            }

            Destroy(gameObject);
        }
    }
}
