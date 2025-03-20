using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public GameObject loadingIcon;

    private void Update()
    {
        loadingIcon.transform.Rotate(0, 0, -200 * Time.deltaTime);
    }
}
