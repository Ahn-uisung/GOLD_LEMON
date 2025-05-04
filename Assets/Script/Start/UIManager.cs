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
    [SerializeField] private Image backgroundImage; // 배경 이미지 UI

    // 씬별 배경 이미지 매핑
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

        // 씬 변경 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;

        // 배경 이미지 매핑 초기화
        backgroundMap = new Dictionary<string, Sprite>
        {
            { "StartScene", startSceneBackground },
            { "LoadingScene", loadingSceneBackground },
            { "GameScene", gameSceneBackground }
        };
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // StartScene이면 UI 활성화, 아니면 숨기기
        startSceneUI.SetActive(scene.name == "StartScene");

        // 씬에 맞는 배경 이미지 변경
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
