using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject loginUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject achievementUI;
    [SerializeField] private GameObject taskbarUI;
    [SerializeField] private GameObject explorerUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowUI(string uiName)
    {
        HideAllUI();
        switch (uiName)
        {
            case "Login":
                loginUI.SetActive(true);
                break;
            case "Options":
                optionsUI.SetActive(true);
                break;
            case "Loading":
                loadingUI.SetActive(true);
                break;
            case "Game":
                gameUI.SetActive(true);
                break;
            case "Achievement":
                achievementUI.SetActive(true);
                break;
            case "Taskbar":
                taskbarUI.SetActive(true);
                break;
            case "Explorer":
                explorerUI.SetActive(true);
                break;
        }
    }

    private void HideAllUI()
    {
        loginUI.SetActive(false);
        optionsUI.SetActive(false);
        loadingUI.SetActive(false);
        gameUI.SetActive(false);
        achievementUI.SetActive(false);
        taskbarUI.SetActive(false);
        explorerUI.SetActive(false);
    }
}
