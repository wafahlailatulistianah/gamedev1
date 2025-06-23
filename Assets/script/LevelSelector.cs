using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public Transform buttonParent;

    void Start()
    {
        for (int i = 1; i <= 3; i++) // hanya 3 level
        {
            GameObject btn = Instantiate(levelButtonPrefab, buttonParent);
            LevelButton lb = btn.GetComponent<LevelButton>();
            lb.levelIndex = i;
        }
    }
}
