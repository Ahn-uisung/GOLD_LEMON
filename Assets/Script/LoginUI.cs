using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField pwField;
    public Button loginButton;

    private void Start()
    {
        // 기존 ID/PW 불러오기
        if (PlayerPrefs.HasKey("SavedID"))
        {
            idField.text = PlayerPrefs.GetString("SavedID");
            pwField.text = PlayerPrefs.GetString("SavedPW");
        }

        loginButton.onClick.AddListener(Login);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Tab 키를 누르면 PW 필드로 이동
            if (idField.isFocused) pwField.Select();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Enter 키로 로그인 실행
            Login();
        }
    }

    private void Login()
    {
        string id = idField.text;
        string pw = pwField.text;

        if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pw))
        {
            // ID & PW 저장
            PlayerPrefs.SetString("SavedID", id);
            PlayerPrefs.SetString("SavedPW", pw);
            PlayerPrefs.Save();

            // 로딩 UI 활성화 후 씬 이동
            UIManager.Instance.ShowUI("Loading");
            Invoke("LoadGameScene", 1.5f); // 1.5초 후 씬 전환
        }
        else
        {
            Debug.Log("ID와 PW를 입력하세요!");
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
