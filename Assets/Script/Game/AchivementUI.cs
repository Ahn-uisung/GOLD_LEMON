using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    public GameObject achievementPanel;

    private void Start()
    {
        achievementPanel.SetActive(false);
    }

    public void ToggleAchievements()
    {
        achievementPanel.SetActive(!achievementPanel.activeSelf);
    }
}
