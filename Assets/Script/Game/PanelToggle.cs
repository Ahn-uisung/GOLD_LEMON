using UnityEngine;
using UnityEngine.UI;

public class PanelToggle : MonoBehaviour
{
    public GameObject panelExplorer; // Panel Ž���� ������Ʈ
    public Button linuxButton; // Linux ��ư

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �޼��� ����
        if (linuxButton != null)
            linuxButton.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        if (panelExplorer != null)
            panelExplorer.SetActive(!panelExplorer.activeSelf);
    }
}
