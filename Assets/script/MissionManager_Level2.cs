using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager_Level2 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public FruitCollector_Level2 fruitCollector;

    public GameObject gameOverPanel;
    public TextMeshProUGUI resultText;
    public PlayerMovement playerMovement;

    public string targetBuah = "Jeruk";
    public int targetJumlah = 5;
    public float waktuMaks = 90f;

    private float waktuTersisa;
    private bool isMissionActive = true;

    void Start()
    {
        waktuTersisa = waktuMaks;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (fruitCollector == null)
            Debug.LogError("FruitCollector_Level2 belum di-assign di Inspector!");
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

        if (playerMovement != null)
            playerMovement.enabled = false;

        PlayerPrefs.SetInt("UnlockedLevel", 3);

        if (gameOverPanel != null && resultText != null)
        {
            resultText.text = "Selamat!\nMisi Selesai!";
            gameOverPanel.SetActive(true);
        }
    }
}
