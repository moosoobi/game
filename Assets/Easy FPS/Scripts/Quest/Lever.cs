using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Lever : MonoBehaviour
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
    public GameObject SuccessDoor;
    public GameObject Triangle;
    public RectTransform TriangleRect;
    
    void Start()
    {
        
        switchStates = new int[switches.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(zzzz){
        if(isFixed){
            if(switches[0].transform.eulerAngles.x>355f&&switches[0].transform.eulerAngles.x<365f&&switches[1].transform.eulerAngles.x>35&&switches[1].transform.eulerAngles.x<45&&switches[2].transform.eulerAngles.x<285&&switches[2].transform.eulerAngles.x>275&&switches[3].transform.eulerAngles.x>315&&switches[3].transform.eulerAngles.x<325){
                UiObject.SetActive(true);
                UiText.text="<b>*오른쪽 비상구표지판에 무슨 변화가 생긴 것 같다.*<b>";
                UiText.color=Color.red;
                StartCoroutine(ExecuteAfterDelayText(3f)); 
                //SuccessDoor.transform.position = new Vector3(-15f, 7f, -7f);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                Vector3 currentRotation = switches[horizontal].transform.eulerAngles;
                currentRotation.x -= 40f;
                
                if (currentRotation.x < 280f){
                    currentRotation.x = 280f;
                }
                switches[horizontal].transform.rotation = Quaternion.Euler(currentRotation);
            }
                if(Input.GetKeyDown(KeyCode.DownArrow)){
                    Vector3 currentRotation = switches[horizontal].transform.eulerAngles;
                    currentRotation.x += 40f;
                    
                    if (currentRotation.x >40f&&currentRotation.x<100f){
                        currentRotation.x = 40f;
                        
                    }
                    switches[horizontal].transform.rotation = Quaternion.Euler(currentRotation);
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow)){
                    horizontal++;
                    if(horizontal>=4){horizontal=0;}
                    if(horizontal==0){TriangleRect.anchoredPosition = new Vector2(-162f, 215f);}
                    if(horizontal==1){TriangleRect.anchoredPosition = new Vector2(-52.4f, 215f);}
                    if(horizontal==2){TriangleRect.anchoredPosition = new Vector2(63f, 215f);}
                    if(horizontal==3){TriangleRect.anchoredPosition = new Vector2(176.2f, 215f);}
                    
                }
                if(Input.GetKeyDown(KeyCode.RightArrow)){
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
                TriangleRect.anchoredPosition = new Vector2(-162f, 215f);
                
            }
            else
            {   
                // 플레이어의 움직임을 다시 활성화
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
                Triangle.SetActive(false);
            }
        }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        zzzz=true;
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        
        zzzz=false;
       
        
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiText.color=Color.white;
        UiObject.SetActive(false);
        
    }
        
    }


    
    
 

