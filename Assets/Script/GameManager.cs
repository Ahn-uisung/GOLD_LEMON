using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavePoint", 1);
        PlayerPrefs.Save();
        Debug.Log("���� ���� �Ϸ�");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavePoint"))
        {
            Debug.Log("����� ���� �ε�");
            // ���� ���� ���� ���� �߰�
        }
        else
        {
            Debug.Log("����� ������ ����");
        }
    }
}
