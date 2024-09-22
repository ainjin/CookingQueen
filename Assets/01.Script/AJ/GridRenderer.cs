using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    public LineRenderer LinePrefabs; // LineRenderer 프리팹을 연결
    public int gridSize = 10; // 그리드 크기 설정
    public float cellSize = 1f; // 각 셀의 크기

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        // 수평선 그리기
        for (int y = -gridSize; y <= gridSize; y++)
        {
            LineRenderer horizontalLine = Instantiate(LinePrefabs, transform);
            horizontalLine.positionCount = 2;
            horizontalLine.SetPosition(0, new Vector3(-gridSize, y * cellSize, 0));
            horizontalLine.SetPosition(1, new Vector3(gridSize, y * cellSize, 0));
        }

        // 수직선 그리기
        for (int x = -gridSize; x <= gridSize; x++)
        {
            LineRenderer verticalLine = Instantiate(LinePrefabs, transform);
            verticalLine.positionCount = 2;
            verticalLine.SetPosition(0, new Vector3(x * cellSize, -gridSize, 0));
            verticalLine.SetPosition(1, new Vector3(x * cellSize, gridSize, 0));
        }
    }
}