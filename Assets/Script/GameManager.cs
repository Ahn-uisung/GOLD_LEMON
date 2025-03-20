using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavePoint", 1);
        PlayerPrefs.Save();
        Debug.Log("게임 저장 완료");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavePoint"))
        {
            Debug.Log("저장된 게임 로드");
            // 게임 상태 복원 로직 추가
        }
        else
        {
            Debug.Log("저장된 데이터 없음");
        }
    }
}
