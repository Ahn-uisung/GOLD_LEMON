using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject loginUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject startSceneUI;
    [SerializeField] private Image backgroundImage; // ��� �̹��� UI

    // ���� ��� �̹��� ����
    public Sprite startSceneBackground;
    public Sprite loadingSceneBackground;
    public Sprite gameSceneBackground;

    private Dictionary<string, Sprite> backgroundMap;

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

        // �� ���� �̺�Ʈ ���
        SceneManager.sceneLoaded += OnSceneLoaded;

        // ��� �̹��� ���� �ʱ�ȭ
        backgroundMap = new Dictionary<string, Sprite>
        {
            { "StartScene", startSceneBackground },
            { "LoadingScene", loadingSceneBackground },
            { "GameScene", gameSceneBackground }
        };
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // StartScene�̸� UI Ȱ��ȭ, �ƴϸ� �����
        startSceneUI.SetActive(scene.name == "StartScene");

        // ���� �´� ��� �̹��� ����
        if (backgroundMap.ContainsKey(scene.name))
        {
            backgroundImage.sprite = backgroundMap[scene.name];
        }
    }

    public void ShowUI(string uiName)
    {
        HideAllUI();
        switch (uiName)
        {
            case "StartScene":
                startSceneUI.SetActive(true);
                break;
            case "Login":
                loginUI.SetActive(true);
                break;
            case "Options":
                optionsUI.SetActive(true);
                break;
        }
    }

    private void HideAllUI()
    {
        loginUI.SetActive(false);
        optionsUI.SetActive(false);
        startSceneUI.SetActive(false);
    }
}
