using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    public InputField idField;
    public InputField pwField;
    public Button loginButton;

    private void Start()
    {
        // ���� �α��� ���� �ҷ�����
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

        // ID�� PW ����
        PlayerPrefs.SetString("SavedID", id);
        PlayerPrefs.SetString("SavedPW", pw);
        PlayerPrefs.Save();

        // �ε� ������ �̵�
        UIManager.Instance.ShowUI("Loading");
        LoadScene();
    }

    private void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
