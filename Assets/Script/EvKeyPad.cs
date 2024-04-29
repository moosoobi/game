using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvKeyPad : MonoBehaviour
{
    public bool zzz=false;
    public bool On=false;
    public GunInventory guninventory;
    public Elevator Ele;
    public GameObject player;
    public GameObject camera;
    public bool zzzz=false;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public GameObject Triangle;
    public RectTransform TriangleRect;
    public TextMeshProUGUI Board;
    public int horizontal=0;
    public int vertical=0;
    public string s="";
    public AudioSource Button;
    public AudioSource Up;
    


   
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0)&&guninventory.IfHand()&&zzz&&!On){
            //On=true;
            //UsingKey();
            Ele.movingUp=true;
        }
        
        if(On){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                horizontal++;
                if(horizontal>4){
                    horizontal=4;
                }else{
                    Vector2 newPosition = TriangleRect.anchoredPosition;
                    newPosition.y += 70f;
                    TriangleRect.anchoredPosition = newPosition;
                    Button.Play();
                }

                
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                horizontal--;
                if(horizontal<0){horizontal=0;}
                else{
                    Vector2 newPosition = TriangleRect.anchoredPosition;
                    newPosition.y -= 70f;
                    TriangleRect.anchoredPosition = newPosition;
                    Button.Play();
                }
                
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                vertical--;
                if(vertical<0){vertical=0;}
                else{
                    Vector2 newPosition = TriangleRect.anchoredPosition;
                    newPosition.x -= 65f;
                    TriangleRect.anchoredPosition = newPosition;
                    Button.Play();
                }
     
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
               vertical++;
                if(vertical>2){vertical=2;}
                else{
                    Vector2 newPosition = TriangleRect.anchoredPosition;
                    newPosition.x += 65f;
                    TriangleRect.anchoredPosition = newPosition;
                    Button.Play();
                }
                
            }
            if(Input.GetKeyDown(KeyCode.Return)){
                Button.Play();
                Enter();
            }

        }
        
    }
    
    public void UsingKey(){ 
        TriangleRect.anchoredPosition = new Vector2(-66.9f, -180.6f);
        UiObject.SetActive(true);
        UiText.text="방향키로 움직이고 엔터로 입력하시오. ";
        Board.gameObject.SetActive(true);
        StartCoroutine(ExecuteAfterDelayText(3f)); 
        
        
        player.transform.position = new Vector3(19.6f, 1.145f, 430.7f);

        // 특정 회전값으로 설정
        player.transform.rotation = Quaternion.Euler(0f, 147f, 0f);
        camera.transform.rotation = Quaternion.Euler(0f, 147f, 0f);

        // 플레이어의 움직임을 차단
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
        Triangle.SetActive(true);
        
        
        
        
    }
    public void DisableKey(){
        
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
        Triangle.SetActive(false);
        UiObject.SetActive(false);
        Board.gameObject.SetActive(false);
        Ele.movingUp=true;
        
    }
    void OnTriggerEnter(Collider other)
    {
           
            if (other.CompareTag("Player")){
                zzz=true;
                Ele.movingUp=true;
            }
        
        
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player")){
            zzz=false;
        }
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiText.color=Color.white;
        UiObject.SetActive(false);
        
    }
    public void Check(){
        if(s=="99"){DisableKey();Up.Play();}
        else{
            UiObject.SetActive(true);
            UiText.text="아무일도 일어나지 않습니다.";
            StartCoroutine(ExecuteAfterDelayText(3f)); 
        }
    }
    public void Enter(){
        if(horizontal==0){
            if(vertical==0){}
            else if(vertical==1){s=s.Substring(0,0);}
            else if(vertical==2){}
        }else if(horizontal==1){
            if(vertical==0){s+='B';}
            else if(vertical==1){s+='0';}
            else if(vertical==2){Check();}
        }else if(horizontal==2){
            if(vertical==0){s+='7';}
            else if(vertical==1){s+='8';}
            else if(vertical==2){s+='9';}
        }else if(horizontal==3){
            if(vertical==0){s+='4';}
            else if(vertical==1){s+='5';}
            else if(vertical==2){s+='6';}
        }else if(horizontal==4){
            if(vertical==0){s+='1';}
            else if(vertical==1){s+='2';}
            else if(vertical==2){s+='3';}
        }
        if(s.Length>2){s=s.Substring(1,2);}
        Board.text=s;
    }

}
