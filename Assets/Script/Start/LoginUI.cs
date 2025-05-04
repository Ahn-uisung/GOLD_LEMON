using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField pwField;
    public Button loginButton;

    private string realPassword = "";
    private Coroutine hideLastCharCoroutine;

    private void Start()
    {
        // ���� ID/PW �ҷ�����
        if (PlayerPrefs.HasKey("SavedID"))
        {
            idField.text = PlayerPrefs.GetString("SavedID");
            realPassword = PlayerPrefs.GetString("SavedPW");
            pwField.text = new string('*', realPassword.Length);
        }

        pwField.onValueChanged.AddListener(OnPasswordChanged);
        loginButton.onClick.AddListener(Login);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Tab ������ PWĭ���� �̵�
        {
            if (idField.isFocused) pwField.Select();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Login();
        }
    }

    private void OnPasswordChanged(string displayed)
    {
        int inputLength = pwField.text.Length;

        if (inputLength < realPassword.Length)
        {
            // ����
            realPassword = realPassword.Substring(0, inputLength);
        }
        else if (inputLength > realPassword.Length)
        {
            // ���� �Էµ� ���ڸ� �߰�
            string added = pwField.text.Substring(realPassword.Length);
            realPassword += added;
        }

        UpdatePasswordDisplay();

        if (hideLastCharCoroutine != null)
        {
            StopCoroutine(hideLastCharCoroutine);
        }
        hideLastCharCoroutine = StartCoroutine(HideLastCharAfterDelay());
    }

    private void UpdatePasswordDisplay()
    {
        if (realPassword.Length == 0)
        {
            pwField.text = "";
        }
        else
        {
            string masked = new string('*', realPassword.Length - 1) + realPassword[^1];
            pwField.text = masked;
        }

        pwField.caretPosition = pwField.text.Length;
    }

    private IEnumerator HideLastCharAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        pwField.text = new string('*', realPassword.Length);
        pwField.caretPosition = pwField.text.Length;
    }

    private void Login()
    {
        string id = idField.text;
        string pw = realPassword; // ���⼭ ��¥ ��й�ȣ ���

        if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pw))
        {
            PlayerPrefs.SetString("SavedID", id);
            PlayerPrefs.SetString("SavedPW", pw);
            PlayerPrefs.Save();

            // �� ��ȯ
            LoadingSceneController.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("ID�� PW�� �Է��ϼ���!");
        }
    }
}
