using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    public Button button;
    public GameObject lockIcon;

    public GameObject instructionPanel;
    public TextMeshProUGUI instructionText;
    public float delayBeforeLoad = 3f;

    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnClickLevelButton);
        }
        else
        {
            Debug.LogError("Button belum di-assign di Inspector.");
        }

        // Cek apakah level terkunci
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        bool isUnlocked = levelIndex <= unlockedLevel;

        button.interactable = isUnlocked;
        if (lockIcon != null)
        {
            lockIcon.SetActive(!isUnlocked);
        }
    }

    void OnClickLevelButton()
    {
        if (instructionPanel != null && instructionText != null)
        {
            instructionPanel.SetActive(true);

            switch (levelIndex)
            {
                case 1:
                    instructionText.text = "Level 1\nKumpulkan 5 Apel dan hindari rintangan!";
                    break;
                case 2:
                    instructionText.text = "Level 2\nKumpulkan buah yang mengandung vitamin C dan hindari buah lainnya!";
                    break;
                case 3:
                    instructionText.text = "Level 3\nKumpulkan 5 Strawberry yang kaya antioksidan.\nHindari buah busuk agar tetap sehat dan waktumu tidak berkurang!";
                    break;
                default:
                    instructionText.text = "Instruksi belum disiapkan untuk level ini.";
                    break;
            }

            StartCoroutine(LoadLevelAfterDelay());
        }
        else
        {
            Debug.LogError("Instruction Panel atau Text belum di-assign.");
        }
    }

    IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        switch (levelIndex)
        {
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;
            case 2:
                SceneManager.LoadScene("levelll2");
                break;
            case 3:
                SceneManager.LoadScene("levelll3");
                break;
            default:
                Debug.LogError("Scene untuk level ini belum tersedia.");
                break;
        }
    }
}
