using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Short_Lever : MonoBehaviour
{
    public ElectricBox electricBox;
    public GameObject[] switches;
    public int[] switchStates;
    public int horizontal=0;
    public int vertical=0;
    public bool isFixed = false;
    public GameObject player;
    public GameObject camera;
    public bool zzzz=false;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public GameObject Triangle;
    public RectTransform TriangleRect;
    public GameObject Exit;
    public Material newMaterial; // 변경할 Material
    public int Lever1=0;
    public int Lever2=0;
    public int Lever3=0;
    public int Lever4=0;
    public int Index=0;
    public GameObject BarCamera;
    public SuccessDoor SuccessDoorScript;
    public AudioSource StoneDoor;
    public TextMeshProUGUI Text2;
    public bool isTalking2=false;
    public TextMeshProUGUI QuestText;
    public GameObject Guide;
    public bool first=true;
    
    void Start()
    {
        
        switchStates = new int[switches.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(zzzz){
        if(isFixed){
            if(Lever1==1&&Lever2==0&&Lever3==3&&Lever4==2&&first){
                first=false;
                BarCamera.SetActive(true);
                StartCoroutine(Camera());
            }
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                if(Index==0){if(Lever1==0){Lever1=3;}Lever1+=1;if(Lever1>3)Lever1=3;}
                else if(Index==1){if(Lever2==0){Lever2=3;}Lever2+=1;if(Lever2>3)Lever2=3;}
                else if(Index==2){if(Lever3==0){Lever3=3;}Lever3+=1;if(Lever3>3)Lever3=3;}
                else if(Index==3){if(Lever4==0){Lever4=3;}Lever4+=1;if(Lever4>3)Lever4=3;}
                
                Vector3 currentRotation = switches[horizontal].transform.eulerAngles;
                currentRotation.x -= 40f;
                
                if (currentRotation.x < 280f){
                    currentRotation.x = 280f;
                }
                switches[horizontal].transform.rotation = Quaternion.Euler(currentRotation);
            }
                if(Input.GetKeyDown(KeyCode.DownArrow)){
                    if(Index==0){Lever1-=1;if(Lever1<0)Lever1=0;}
                    else if(Index==1){Lever2-=1;if(Lever2<0)Lever2=0;}
                    else if(Index==2){Lever3-=1;if(Lever3<0)Lever3=0;}
                    else if(Index==3){Lever4-=1;if(Lever4<0)Lever4=0;}
                    Vector3 currentRotation = switches[horizontal].transform.eulerAngles;
                    currentRotation.x += 40f;
                    
                    if (currentRotation.x >40f&&currentRotation.x<100f){
                        currentRotation.x = 40f;
                        
                    }
                    switches[horizontal].transform.rotation = Quaternion.Euler(currentRotation);
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow)){
                    Index-=1;
                    if(Index<0){Index=3;}
                    horizontal--;
                    if(horizontal<0){horizontal=3;}
                    if(horizontal==0){TriangleRect.anchoredPosition = new Vector2(-162f, 215f);}
                    if(horizontal==1){TriangleRect.anchoredPosition = new Vector2(-52.4f, 215f);}
                    if(horizontal==2){TriangleRect.anchoredPosition = new Vector2(63f, 215f);}
                    if(horizontal==3){TriangleRect.anchoredPosition = new Vector2(176.2f, 215f);}
                    
                }
                if(Input.GetKeyDown(KeyCode.RightArrow)){
                    Index+=1;
                    if(Index>3){Index=0;}
                    horizontal++;
                    if(horizontal>=4){horizontal=0;}
                    if(horizontal==0){TriangleRect.anchoredPosition = new Vector2(-162f, 215f);}
                    if(horizontal==1){TriangleRect.anchoredPosition = new Vector2(-52.4f, 215f);}
                    if(horizontal==2){TriangleRect.anchoredPosition = new Vector2(63f, 215f);}
                    if(horizontal==3){TriangleRect.anchoredPosition = new Vector2(176.2f, 215f);}
                }
        }
        if (Input.GetMouseButtonDown(0)&&electricBox.ReturnDoorLock())
        {
            Setting();
            UiObject.SetActive(true);
            UiText.text="방향키로 조작하시오.";
            StartCoroutine(ExecuteAfterDelayText(3f)); 
            isFixed = !isFixed;
            // 상태에 따라 플레이어 제어 여부를 조절
            if (isFixed)
            {
                // 특정 위치로 이동
                player.transform.position = new Vector3(354.6f, 1f, 424.16f);

                // 특정 회전값으로 설정
                player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                camera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

                // 플레이어의 움직임을 차단
                player.GetComponent<MouseLookScript>().enabled = false;
                player.GetComponent<PlayerMovementScript>().enabled = false;
                Triangle.SetActive(true);
                if(horizontal>=4){horizontal=0;}
                if(horizontal==0){TriangleRect.anchoredPosition = new Vector2(-162f, 215f);}
                if(horizontal==1){TriangleRect.anchoredPosition = new Vector2(-52.4f, 215f);}
                if(horizontal==2){TriangleRect.anchoredPosition = new Vector2(63f, 215f);}
                if(horizontal==3){TriangleRect.anchoredPosition = new Vector2(176.2f, 215f);}
                
            }
            else
            {   
                // 플레이어의 움직임을 다시 활성화
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
                Triangle.SetActive(false);
                UiObject.SetActive(false);
            }
        }
        }
    }
    public void Setting(){
        Vector3 currentRotation = switches[horizontal].transform.eulerAngles;
        horizontal=0;
        Lever1=3;
        Lever2=3;
        Lever3=3;
        Lever4=3;
        Index=0;
        currentRotation.x = 280f;
        
        switches[0].transform.rotation = Quaternion.Euler(currentRotation);
        switches[1].transform.rotation = Quaternion.Euler(currentRotation);
        switches[2].transform.rotation = Quaternion.Euler(currentRotation);
        switches[3].transform.rotation = Quaternion.Euler(currentRotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            zzzz=true;
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player")){
            zzzz=false;
        }
       
        
    }
    public void QuestActive(){
        Text2.text="천장에 있는 동그란 전등을 사격하라.";
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiText.color=Color.white;
        UiObject.SetActive(false);
        
    }
    private IEnumerator Camera()
    {
        SuccessDoorScript.Success();
        StoneDoor.Play();
        yield return new WaitForSeconds(3.0f);
        BarCamera.SetActive(false);
        Guide.SetActive(true);
    }
    
}
