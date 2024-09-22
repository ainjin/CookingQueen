using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    public LineRenderer LinePrefabs; // LineRenderer �������� ����
    public int gridSize = 10; // �׸��� ũ�� ����
    public float cellSize = 1f; // �� ���� ũ��

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        // ���� �׸���
        for (int y = -gridSize; y <= gridSize; y++)
        {
            LineRenderer horizontalLine = Instantiate(LinePrefabs, transform);
            horizontalLine.positionCount = 2;
            horizontalLine.SetPosition(0, new Vector3(-gridSize, y * cellSize, 0));
            horizontalLine.SetPosition(1, new Vector3(gridSize, y * cellSize, 0));
        }

        // ������ �׸���
        for (int x = -gridSize; x <= gridSize; x++)
        {
            LineRenderer verticalLine = Instantiate(LinePrefabs, transform);
            verticalLine.positionCount = 2;
            verticalLine.SetPosition(0, new Vector3(x * cellSize, -gridSize, 0));
            verticalLine.SetPosition(1, new Vector3(x * cellSize, gridSize, 0));
        }
    }
}