using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndingMonitor : MonoBehaviour
{
    public GameObject Cursur;
    public GameObject MonitorUi;
    public GameObject NewMedicineDetail;
    public GameObject TrashDetail;
    public GameObject TraumDetail;
    public GameObject Papa1;
    public GameObject Papa2;
    public GameObject Papa3;
    public GameObject Papa4;
    public GameObject Papa5;
    public GameObject Papa6;
    public GameObject LabDetail;
    public GameObject EndingEnemy;
    public RectTransform uiRectTransform;
    public GameObject player;
    public GameObject EndingCamera;
    public GameObject EndingSpot;
    public GameObject EndingVi;
    public VideoPlayer EndingPlayer;
    public RealBoss Boss;
    public bool Home=false;
    public bool Clear=false;
    public bool IfVoice1=false;
    public bool IfVoice2=false;
    public bool IfMember=false;
    public bool IfNewMedicine=false;
    public bool IfEnergy=false;
    public bool IfTrash=false;
    public bool IfTraum=false;
    public bool IfLab=false;
    public bool IfPapa1=false;
    public bool IfPapa2=false;
    public bool IfPapa3=false;
    public bool IfPapa4=false;
    public bool IfPapa5=false;
    public bool IfPapa6=false;
    public bool First=true;
    public bool FirstVector=true;
    public bool zzz=false;
    public bool isMoving=false;
    public float CameramoveSpeed = 2.0f; // 이동 속도
    public float rotationSpeed = 2.0f; // 회전 속도
    public float moveSpeed = 500f;
    public AudioSource Voice1;
    public AudioSource Voice2;
    public AudioSource Pick;
    public AudioSource EndingSound;
    private Vector3 FirstDirection;

    public void MonitorOn(){
        Home=true;
        MonitorUi.SetActive(true);
        Cursur.SetActive(true);
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        uiRectTransform.anchoredPosition = new Vector2(0, 0);
    }
    void Update()
    {
        if (isMoving)
        {
            
            //EndingCamera.transform.position = Vector3.MoveTowards(EndingCamera.transform.position, EndingSpot.transform.position, CameramoveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.Euler(0f, -90f, 0f);
            EndingCamera.transform.rotation = Quaternion.Slerp(EndingCamera.transform.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            if (EndingCamera.transform.rotation == targetRotation)
            {
                isMoving=false;
                StartCoroutine(EndingLogo());
                
                
            }
        }
        if(Clear&&zzz&&First){if(Input.GetMouseButtonDown(0)){MonitorOn();First=false;}}
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
        if(Home){
            if(currentX>-450&&currentX<-380&&currentY>-250&&currentY<-170){
                if(Input.GetMouseButtonDown(0)){
                IfTrash=true;
                Home=false;
                TrashDetail.SetActive(true);
                Pick.Play();
                }
       

            }
            if(currentY>30&&currentY<110){
                
            }
            else if(currentY>140&&currentY<230){
                if(currentX>-420&&currentX<-350){
                    if(Input.GetMouseButtonDown(0)){
                        Home=false;
                        IfTraum=true;
                        TraumDetail.SetActive(true);
                        Pick.Play();
                    }
                    
                }
                else if(currentX>-320&&currentX<-240){
                    if(Input.GetMouseButtonDown(0)){
                    }
                    
                }
                else if(currentX>-210&&currentX<-120){
                    if(Input.GetMouseButtonDown(0)){
                        NewMedicineDetail.SetActive(true);
                        IfNewMedicine=true;
                        Home=false;
                        Pick.Play();
                    }
                    
                }
                else if(currentX>-110&&currentX<-10){
                    if(Input.GetMouseButtonDown(0)){
                        LabDetail.SetActive(true);
                        IfLab=true;
                        Home=false;
                        Pick.Play();
                    }
                }
            }
        }
        if(IfTrash){
            if(currentX>-220&&currentX<-160&&currentY>60&&currentY<120){
                if(Input.GetMouseButtonDown(0)){
                    Papa1.SetActive(true);
                    Pick.Play();
                    IfPapa1=true;
                    IfTrash=false;
                    
                }
            }
            if(currentX>-20&&currentX<40&&currentY>60&&currentY<120){
                if(Input.GetMouseButtonDown(0)){
                    Papa2.SetActive(true);
                    Pick.Play();
                    IfPapa2=true;
                    IfTrash=false;
                }
            }
            if(currentX>180&&currentX<240&&currentY>60&&currentY<120){
                if(Input.GetMouseButtonDown(0)){
                    Papa3.SetActive(true);
                    Pick.Play();
                    IfPapa3=true;
                    IfTrash=false;
                }
            }
            if(currentX>-220&&currentX<-160&&currentY>-40&&currentY<20){
                if(Input.GetMouseButtonDown(0)){
                    Papa4.SetActive(true);
                    Pick.Play();
                    IfPapa4=true;
                    IfTrash=false;
                }
            }
            if(currentX>-120&&currentX<-60&&currentY>-40&&currentY<20){
                if(Input.GetMouseButtonDown(0)){
                    Papa5.SetActive(true);
                    Pick.Play();
                    IfPapa5=true;
                    IfTrash=false;
                }
            }
            if(currentX>80&&currentX<140&&currentY>-40&&currentY<20){
                if(Input.GetMouseButtonDown(0)){
                    Papa6.SetActive(true);
                    Pick.Play();
                    IfPapa6=true;
                    IfTrash=false;
                }
            }
            /*
            if(currentX>265&&currentX<290&&currentY>150&&currentY<175){
                if(Input.GetMouseButtonDown(0)){
                    IfTrash=false;
                    Home=true;
                    TrashDetail.SetActive(false);
                    Pick.Play();
                    
                }
            }
            */
        }
        /*
        if(IfTraum){
            if(currentX>265&&currentX<305&&currentY>260&&currentY<300){
                if(Input.GetMouseButtonDown(0)){
                    IfTraum=false;
                    MonitorUi.SetActive(false);
                    Pick.Play();
                    Boss.LightOn();
                    
                    StartCoroutine(EndingMove());
                    Cursur.SetActive(false);
                    
                }
            }
        }
        */
        if(IfTraum){
            if(currentX>260&&currentX<305&&currentY>260&&currentY<305){
                if(Input.GetMouseButtonDown(0)){
                    TraumDetail.SetActive(false);
                    IfTraum=false;
                    Home=true;
                    Pick.Play();
                }
            }
        }
        if(IfNewMedicine){
            if(currentX>230&&currentX<260&&currentY>280&&currentY<300){
                if(Input.GetMouseButtonDown(0)){
                    NewMedicineDetail.SetActive(false);
                    IfNewMedicine=false;
                    Home=true;
                    Pick.Play();
                }
            }
        }
        if(IfLab){
            if(currentX>420&&currentX<455&&currentY>180&&currentY<210){
                if(Input.GetMouseButtonDown(0)){
                    LabDetail.SetActive(false);
                    IfLab=false;
                    Home=true;
                    Pick.Play();
                }
            }
        }
        if(IfPapa1){
            if(currentX>420&&currentX<490&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa1=false;
                    IfPapa2=true;
                    Papa2.SetActive(true);
                    Papa1.SetActive(false);
                    Pick.Play();
                }
            }
        }
        else if(IfPapa2){
            if(currentX>-470&&currentX<-400&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa2=false;
                    IfPapa1=true;
                    Papa2.SetActive(false);
                    Papa1.SetActive(true);
                    Pick.Play();
                }
            }
            if(currentX>420&&currentX<490&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa3=true;
                    IfPapa2=false;
                    Papa3.SetActive(true);
                    Papa2.SetActive(false);
                    Pick.Play();
                }
            }
        }
        else if(IfPapa3){
            if(currentX>-470&&currentX<-400&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa3=false;
                    IfPapa2=true;
                    Papa2.SetActive(true);
                    Papa3.SetActive(false);
                    Pick.Play();
                }
            }
            if(currentX>420&&currentX<490&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa3=false;
                    IfPapa4=true;
                    Papa4.SetActive(true);
                    Papa3.SetActive(false);
                    Pick.Play();
                }
            }
        }
        else if(IfPapa4){
            if(currentX>-470&&currentX<-400&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa4=false;
                    IfPapa3=true;
                    Papa3.SetActive(true);
                    Papa4.SetActive(false);
                    Pick.Play();
                }
            }
            if(currentX>420&&currentX<490&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa4=false;
                    IfPapa5=true;
                    Papa5.SetActive(true);
                    Papa4.SetActive(false);
                    Pick.Play();
                }
            }
        }
        else if(IfPapa5){
            if(currentX>-470&&currentX<-400&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa5=false;
                    IfPapa4=true;
                    Papa4.SetActive(true);
                    Papa5.SetActive(false);
                    Pick.Play();
                }
            }
            if(currentX>420&&currentX<490&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa5=false;
                    IfPapa6=true;
                    Papa6.SetActive(true);
                    Papa5.SetActive(false);
                    Pick.Play();
                }
            }
        }
        else if(IfPapa6){
            if(currentX>-470&&currentX<-400&&currentY>-80&&currentY<60){
                if(Input.GetMouseButtonDown(0)){
                    IfPapa6=false;
                    IfPapa5=true;
                    Papa5.SetActive(true);
                    Papa6.SetActive(false);
                    Pick.Play();
                }
            }
            if(currentX>445&&currentX<480&&currentY>250&&currentY<280){
                if(Input.GetMouseButtonDown(0)){
                    MonitorUi.SetActive(false);
                    Pick.Play();
                    Boss.LightOn();
                    
                    StartCoroutine(EndingMove());
                    Cursur.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            zzz=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            zzz=false;
        }
    }
    public IEnumerator EndingLogo(){
        yield return new WaitForSeconds(2.0f);
        EndingVi.SetActive(true);
        EndingPlayer.Play();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Opening");

    }
    public IEnumerator EndingMove(){
        EndingEnemy.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        
        EndingCamera.SetActive(true);
        isMoving=true;
    }
}
