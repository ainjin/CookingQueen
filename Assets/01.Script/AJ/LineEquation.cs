using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineEquation : MonoBehaviour
{
    public InputField slopeInput;
    public InputField interceptInput;
    public GameObject lineRendererPrefab;

    public void DrawLine()
    {
        float slope = float.Parse(slopeInput.text);    // 기울기 a
        float intercept = float.Parse(interceptInput.text); // 절편 b

        // 라인 렌더러를 이용해 직선을 그립니다.
        LineRenderer lineRenderer = Instantiate(lineRendererPrefab).GetComponent<LineRenderer>();

        Vector3 startPoint = new Vector3(-10, slope * -10 + intercept, 0); // (x1, y1)
        Vector3 endPoint = new Vector3(10, slope * 10 + intercept, 0);     // (x2, y2)

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}