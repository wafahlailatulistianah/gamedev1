using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitCollector_Level2 : MonoBehaviour
{
    public int jerukCount = 0;
    public TextMeshProUGUI jerukText;
    public MissionManager_Level2 missionManager;

    public void TambahJeruk()
    {
        jerukCount++;
        UpdateUI();
    }

    public void KurangiWaktu(float detik)
    {
        if (missionManager != null)
        {
            missionManager.KurangiWaktu(detik);
        }
        else
        {
            Debug.LogWarning("MissionManager belum di-assign di Inspector.");
        }
    }

    public void UpdateUI()
    {
        if (jerukText != null)
        {
            jerukText.text = "Jeruk: " + jerukCount;
        }
        else
        {
            Debug.LogWarning("Text Jeruk belum di-assign.");
        }
    }
}
