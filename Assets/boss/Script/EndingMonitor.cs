using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingMonitor : MonoBehaviour
{
    public GameObject Cursur;
    public GameObject MonitorUi;
    public GameObject MemberDetail;
    public GameObject Voice1Detail;
    public GameObject NewMedicineDetail;
    public GameObject Voice2Detail;
    public GameObject EnergyDetail;
    public RectTransform uiRectTransform;
    public GameObject player;
    public bool Home=false;
    public bool Clear=false;
    public float moveSpeed = 500f;

    public void MonitorOn(){
        MonitorUi.SetActive(true);
        Cursur.SetActive(true);
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        uiRectTransform.anchoredPosition = new Vector2(0, 0);
    }
    void Update()
    {
        float currentX = uiRectTransform.anchoredPosition.x;
        float currentY = uiRectTransform.anchoredPosition.y;

        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        // 입력에 따라 이동 방향 설정
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        // 현재 anchoredPosition 가져오기
        Vector2 currentPosition = uiRectTransform.anchoredPosition;

        // 입력에 따라 이동한 위치 계산
        Vector2 newPosition = currentPosition + moveDirection*moveSpeed * Time.deltaTime;

        // 새로 계산된 위치로 anchoredPosition 설정
        uiRectTransform.anchoredPosition = newPosition;
        if(currentX>-540f&&currentX<-440f){}
    }
}
