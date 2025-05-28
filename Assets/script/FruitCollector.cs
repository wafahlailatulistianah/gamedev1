using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitCollector : MonoBehaviour
{
    public int apelCount = 0;
    public TextMeshProUGUI apelText;
    public MissionManager missionManager;

    public void TambahApel()
    {
        apelCount++;
        UpdateUI();
    }

    public void KurangiWaktu(float detik)
    {
        missionManager.KurangiWaktu(detik);
    }

    public void UpdateUI()
    {
        apelText.text = "Apel: " + apelCount;
    }
}
