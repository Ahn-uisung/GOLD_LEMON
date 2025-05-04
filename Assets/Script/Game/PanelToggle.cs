using UnityEngine;
using UnityEngine.UI;

public class PanelToggle : MonoBehaviour
{
    public GameObject panelExplorer; // Panel 탐색기 오브젝트
    public Button linuxButton; // Linux 버튼

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        if (linuxButton != null)
            linuxButton.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        if (panelExplorer != null)
            panelExplorer.SetActive(!panelExplorer.activeSelf);
    }
}
