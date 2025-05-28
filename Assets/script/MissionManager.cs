using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI timerText;
    public FruitCollector fruitCollector; // drag script FruitCollector di player

    public string targetBuah = "Apel";
    public int targetJumlah = 5;
    public float waktuMaks = 30f;

    private float waktuTersisa;
    private bool isMissionActive = true;

    void Start()
    {
        waktuTersisa = waktuMaks;
        missionText.text = $"Misi: Kumpulkan {targetJumlah} {targetBuah} dalam {waktuMaks} detik!";
    }

    void Update()
    {
        if (!isMissionActive) return;

        waktuTersisa -= Time.deltaTime;
        timerText.text = $"Waktu: {Mathf.CeilToInt(waktuTersisa)}s";

        if (waktuTersisa <= 0)
        {
            GameOver("Waktu habis!");
        }

        if (fruitCollector.apelCount >= targetJumlah)
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
        missionText.text = "Gagal! " + pesan;
        // Tambahkan efek atau panel "Game Over" kalau ingin
    }

    void SelesaiMisi()
    {
        isMissionActive = false;
        missionText.text = "Selamat! Misi Selesai!";
        // Bisa tambahkan animasi, suara, atau lanjut level
    }
}
