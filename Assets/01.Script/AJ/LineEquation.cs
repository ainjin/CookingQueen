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
        float slope = float.Parse(slopeInput.text);    // ���� a
        float intercept = float.Parse(interceptInput.text); // ���� b

        // ���� �������� �̿��� ������ �׸��ϴ�.
        LineRenderer lineRenderer = Instantiate(lineRendererPrefab).GetComponent<LineRenderer>();

        Vector3 startPoint = new Vector3(-10, slope * -10 + intercept, 0); // (x1, y1)
        Vector3 endPoint = new Vector3(10, slope * 10 + intercept, 0);     // (x2, y2)

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}