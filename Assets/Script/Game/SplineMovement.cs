using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    public SplineContainer spline; // 스플라인 참조
    public float speed = 5f; // 이동 속도
    private float t = 0f; // 현재 스플라인 진행률 (0~1)

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            t -= Time.deltaTime * speed / spline.CalculateLength(); // 왼쪽 이동
        }
        if (Input.GetKey(KeyCode.D))
        {
            t += Time.deltaTime * speed / spline.CalculateLength(); // 오른쪽 이동
        }

        t = Mathf.Clamp01(t); // 0~1 범위 유지
        transform.position = spline.EvaluatePosition(t); // 스플라인 위치 적용
    }
}
