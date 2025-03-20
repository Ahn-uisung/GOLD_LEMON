using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    public InputField idField;
    public InputField pwField;
    public Button loginButton;

    private void Start()
    {
        // 이전 로그인 정보 불러오기
        if (PlayerPrefs.HasKey("SavedID"))
        {
            idField.text = PlayerPrefs.GetString("SavedID");
            pwField.text = PlayerPrefs.GetString("SavedPW");
        }

        loginButton.onClick.AddListener(Login);
    }

    private void Login()
    {
        string id = idField.text;
        string pw = pwField.text;

        // ID와 PW 저장
        PlayerPrefs.SetString("SavedID", id);
        PlayerPrefs.SetString("SavedPW", pw);
        PlayerPrefs.Save();

        // 로드 씬으로 이동
        UIManager.Instance.ShowUI("Loading");
        LoadScene();
    }

    private void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
