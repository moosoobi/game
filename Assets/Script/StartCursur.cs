using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartCursur : MonoBehaviour
{
    public GameObject Cursur;
    public GameObject StartCamera;
    public GameObject StartLogo;
    public GameObject Hp;
    public GameObject Quest;
    public GameObject player;
    public GameObject OpeningVideo;
    public GameObject Opening;
    public VideoPlayer videoPlayer;
    public PlayerMovementScript Move;
    public First_J j;
    public RectTransform uiRectTransform;
    public float moveSpeed = 500f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLookScript>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void Update()
    {
        float currentX = uiRectTransform.anchoredPosition.x;
        float currentY = uiRectTransform.anchoredPosition.y;

        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        // 현재 anchoredPosition 가져오기
        Vector2 currentPosition = uiRectTransform.anchoredPosition;

        // 입력에 따라 이동한 위치 계산
        Vector2 newPosition = currentPosition + moveDirection*moveSpeed * Time.deltaTime;

        // 새로 계산된 위치로 anchoredPosition 설정
        uiRectTransform.anchoredPosition = newPosition;
        
        if(currentX>-60&&currentX<80&&currentY>-290&&currentY<-140){
            if(Input.GetMouseButtonDown(0)){
                StartCamera.SetActive(false);
                
                OpeningVideo.SetActive(true);
                Cursur.SetActive(false);
                StartLogo.SetActive(false);
                Hp.SetActive(false);
                Quest.SetActive(false);
                Move.IfCross=true;
            }
        }
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        Opening.SetActive(false);
        Quest.SetActive(true);
        Hp.SetActive(true);
        j.Starting();
    }
    
}
