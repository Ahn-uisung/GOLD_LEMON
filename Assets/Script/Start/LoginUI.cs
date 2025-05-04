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
        // 기존 ID/PW 불러오기
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
        if (Input.GetKeyDown(KeyCode.Tab)) // Tab 누르면 PW칸으로 이동
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
            // 삭제
            realPassword = realPassword.Substring(0, inputLength);
        }
        else if (inputLength > realPassword.Length)
        {
            // 새로 입력된 문자만 추가
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
        string pw = realPassword; // 여기서 진짜 비밀번호 사용

        if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pw))
        {
            PlayerPrefs.SetString("SavedID", id);
            PlayerPrefs.SetString("SavedPW", pw);
            PlayerPrefs.Save();

            // 씬 전환
            LoadingSceneController.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("ID와 PW를 입력하세요!");
        }
    }
}
