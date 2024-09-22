using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도
    private Vector3 targetPosition; // 목표 위치
    private bool isMoving = false; // 플레이어가 이동 중인지 체크
    public GameObject markerPrefab; // 선택한 위치를 보여줄 마커

    private GameObject currentMarker; // 현재 마커를 저장

    void Update()
    {
        // 이동 중이 아니고 마우스 왼쪽 클릭이 발생했을 때
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            // 클릭한 좌표 구하기
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedPosition.z = 0; // z축을 0으로 고정 (2D 환경)

            // 목표 위치 설정
            targetPosition = clickedPosition;

            // 기존 마커가 있으면 제거하고 새 마커 생성
            if (currentMarker != null)
            {
                Destroy(currentMarker);
            }
            currentMarker = Instantiate(markerPrefab, targetPosition, Quaternion.identity);

            // 이동 시작
            isMoving = true;
        }

        // 플레이어가 목표 위치로 이동
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 목표 위치에 도착했으면 이동 중 상태 해제
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                Destroy(currentMarker); // 마커 제거
            }
        }
    }
}
