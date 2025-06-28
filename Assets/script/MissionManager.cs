using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public FruitCollector fruitCollector;

    public GameObject gameOverPanel;
    public TextMeshProUGUI resultText;

    public PlayerMovement playerMovement; // Tambahan

    public string targetBuah = "Apel";
    public int targetJumlah = 5;
    public float waktuMaks = 50f;

    private float waktuTersisa;
    private bool isMissionActive = true;

    void Start()
    {
        waktuTersisa = waktuMaks;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Sembunyikan panel game over di awal
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
        Debug.Log("Gagal! " + pesan);

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (gameOverPanel != null && resultText != null)
        {
            resultText.text = "Gagal!\n" + pesan;
            gameOverPanel.SetActive(true);
        }
    }

    void SelesaiMisi()
    {
        isMissionActive = false;
        Debug.Log("Selamat! Misi Selesai!");

        PlayerPrefs.SetInt("UnlockedLevel", 2); // Buka level 2

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (gameOverPanel != null && resultText != null)
        {
            resultText.text = "Selamat!\nMisi Selesai!";
            gameOverPanel.SetActive(true);
        }
    }
}
