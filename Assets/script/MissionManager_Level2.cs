using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager_Level2 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public FruitCollector_Level2 fruitCollector;

    public string targetBuah = "Jeruk";
    public int targetJumlah = 5;
    public float waktuMaks = 50f;

    private float waktuTersisa;
    private bool isMissionActive = true;

    void Start()
    {
        waktuTersisa = waktuMaks;

        if (fruitCollector == null)
        {
            Debug.LogError("FruitCollector_Level2 belum di-assign di Inspector!");
        }
    }

    void Update()
    {
        if (!isMissionActive) return;

        waktuTersisa -= Time.deltaTime;
        timerText.text = $"Waktu: {Mathf.CeilToInt(waktuTersisa)}s";

        if (waktuTersisa <= 0)
        {
            waktuTersisa = 0;
            GameOver("Waktu habis!");
        }

        if (fruitCollector != null && fruitCollector.jerukCount >= targetJumlah)
        {
            SelesaiMisi();
        }
    }

    public void KurangiWaktu(float jumlah)
    {
        if (!isMissionActive) return;

        waktuTersisa -= jumlah;
        if (waktuTersisa <= 0)
        {
            waktuTersisa = 0;
            GameOver("Waktu habis karena buah salah!");
        }
    }

    public void GameOver(string pesan)
    {
        isMissionActive = false;
        Debug.Log("Gagal! " + pesan);
    }

    void SelesaiMisi()
    {
        isMissionActive = false;
        Debug.Log("Selamat! Misi Selesai!");
        PlayerPrefs.SetInt("UnlockedLevel", 3); // membuka level 3
    }
}
