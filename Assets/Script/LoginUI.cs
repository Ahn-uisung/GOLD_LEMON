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
        // ���� ID/PW �ҷ�����
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
            // Tab Ű�� ������ PW �ʵ�� �̵�
            if (idField.isFocused) pwField.Select();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Enter Ű�� �α��� ����
            Login();
        }
    }

    private void Login()
    {
        string id = idField.text;
        string pw = pwField.text;

        if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pw))
        {
            // ID & PW ����
            PlayerPrefs.SetString("SavedID", id);
            PlayerPrefs.SetString("SavedPW", pw);
            PlayerPrefs.Save();

            // �ε� UI Ȱ��ȭ �� �� �̵�
            UIManager.Instance.ShowUI("Loading");
            Invoke("LoadGameScene", 1.5f); // 1.5�� �� �� ��ȯ
        }
        else
        {
            Debug.Log("ID�� PW�� �Է��ϼ���!");
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
