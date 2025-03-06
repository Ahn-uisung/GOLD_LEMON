using UnityEngine;
using UnityEngine.Splines;

public class SplineMovement : MonoBehaviour
{
    public SplineContainer spline; // ���ö��� ����
    public float speed = 5f; // �̵� �ӵ�
    private float t = 0f; // ���� ���ö��� ����� (0~1)

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            t -= Time.deltaTime * speed / spline.CalculateLength(); // ���� �̵�
        }
        if (Input.GetKey(KeyCode.D))
        {
            t += Time.deltaTime * speed / spline.CalculateLength(); // ������ �̵�
        }

        t = Mathf.Clamp01(t); // 0~1 ���� ����
        transform.position = spline.EvaluatePosition(t); // ���ö��� ��ġ ����
    }
}
