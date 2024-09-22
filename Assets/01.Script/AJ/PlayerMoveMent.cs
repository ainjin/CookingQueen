using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    private Vector3 targetPosition; // ��ǥ ��ġ
    private bool isMoving = false; // �÷��̾ �̵� ������ üũ
    public GameObject markerPrefab; // ������ ��ġ�� ������ ��Ŀ

    private GameObject currentMarker; // ���� ��Ŀ�� ����

    void Update()
    {
        // �̵� ���� �ƴϰ� ���콺 ���� Ŭ���� �߻����� ��
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            // Ŭ���� ��ǥ ���ϱ�
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedPosition.z = 0; // z���� 0���� ���� (2D ȯ��)

            // ��ǥ ��ġ ����
            targetPosition = clickedPosition;

            // ���� ��Ŀ�� ������ �����ϰ� �� ��Ŀ ����
            if (currentMarker != null)
            {
                Destroy(currentMarker);
            }
            currentMarker = Instantiate(markerPrefab, targetPosition, Quaternion.identity);

            // �̵� ����
            isMoving = true;
        }

        // �÷��̾ ��ǥ ��ġ�� �̵�
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� ���������� �̵� �� ���� ����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                Destroy(currentMarker); // ��Ŀ ����
            }
        }
    }
}
