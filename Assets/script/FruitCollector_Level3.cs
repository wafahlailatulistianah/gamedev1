using System.Collections;
using UnityEngine;
using TMPro;

public class FruitCollector_Level3 : MonoBehaviour
{
    public int strawberryCount = 0;
    public TextMeshProUGUI strawberryText;
    public MissionManager_Level3 missionManager;

    public void TambahStrawberry()
    {
        strawberryCount++;
        UpdateUI();
    }

    public void KurangiWaktu(float detik)
    {
        missionManager.KurangiWaktu(detik);
    }

    public void UpdateUI()
    {
        strawberryText.text = "Strawberry: " + strawberryCount;
    }
}
