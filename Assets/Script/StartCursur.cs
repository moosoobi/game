using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartCursur : MonoBehaviour
{
    public GameObject Cursur1;
    public GameObject StartCamera;
    public GameObject StartLogo;
    public GameObject Hp;
    public GameObject Inven;
    public GameObject Quest;
    public GameObject OpeningVideo;
    public GameObject Opening;
    public VideoPlayer videoPlayer;
    public RectTransform uiRectTransform;
    public AudioSource RoomBg;
    public AudioSource StartBg;
    public AudioSource Click;
    public float moveSpeed = 500f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
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
        if (newPosition.x < -630f)
        {
            newPosition.x = -630f;
        }
        if (newPosition.x > 630f)
        {
            newPosition.x = 630f;
        }
        // y 방향으로 이동 제한
        if (newPosition.y > 350f)
        {
            newPosition.y = 350f;
        }
        if (newPosition.y < -350f)
        {
            newPosition.y = -350f;
        }

        // 새로 계산된 위치로 anchoredPosition 설정
        uiRectTransform.anchoredPosition = newPosition;
        
        
        if(currentX>-390&&currentX<-130&&currentY>-220&&currentY<-90){
            if(Input.GetMouseButtonDown(0)){
                Click.Play();
                StartCamera.SetActive(false);
                StartBg.Stop();
                OpeningVideo.SetActive(true);
                Cursur1.SetActive(false);
                StartLogo.SetActive(false);
                Hp.SetActive(false);
                Quest.SetActive(false);
                
            }
        }
        if(currentX>160&&currentX<440&&currentY>-220&&currentY<-90){
            if(Input.GetMouseButtonDown(0)){
                Click.Play();
                SceneManager.LoadScene("Short");
            }
        }
    }
    private IEnumerator Loading1(){

        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene("Room");
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        Opening.SetActive(false);
        Quest.SetActive(true);
        Hp.SetActive(true);
        
        Inven.SetActive(true);
        RoomBg.Play();
    }
    
}
