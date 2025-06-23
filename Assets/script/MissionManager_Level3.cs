using UnityEngine;
using TMPro;

public class MissionManager_Level3 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public FruitCollector_Level3 fruitCollector;

    public string targetBuah = "Strawberry";
    public int targetJumlah = 5;
    public float waktuMaks = 50f;

    private float waktuTersisa;
    private bool isMissionActive = true;

    void Start()
    {
        waktuTersisa = waktuMaks;
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

        if (fruitCollector.strawberryCount >= targetJumlah)
        {
            SelesaiMisi();
        }
    }

    public void KurangiWaktu(float jumlah)
    {
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
        PlayerPrefs.SetInt("UnlockedLevel", 4); // opsional kalau ada level 4
    }
}
