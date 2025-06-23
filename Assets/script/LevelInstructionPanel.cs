using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInstructionPanel : MonoBehaviour
{
    public GameObject instructionPanel;
    public Button playButton;
    public string sceneToLoad = "SampleScene";

    void Start()
    {
        instructionPanel.SetActive(false); // Panel sembunyi di awal
        playButton.onClick.AddListener(PlayLevel);
    }

    public void ShowInstruction()
    {
        instructionPanel.SetActive(true);
    }

    void PlayLevel()
    {
        SceneManager.LoadScene(sceneToLoad); // Masuk ke level
    }
}
