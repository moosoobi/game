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
    public TextMeshProUGUI Text;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public GameObject SuccessDoor;
    
    void Start()
    {
        
        switchStates = new int[switches.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(zzzz){
        if(isFixed){
            
            
            if(switches[0].transform.eulerAngles.x<365f&&switches[0].transform.eulerAngles.x<355f&&switches[1].transform.eulerAngles.x>35&&switches[1].transform.eulerAngles.x<45&&switches[2].transform.eulerAngles.x<285&&switches[2].transform.eulerAngles.x>275&&switches[3].transform.eulerAngles.x>315&&switches[3].transform.eulerAngles.x<325){
                UiObject.SetActive(true);
                UiText.text="문이 열린 것 같은 소리가 들린 것 같다.";
                StartCoroutine(ExecuteAfterDelayText(3f)); 
                SuccessDoor.transform.position = new Vector3(-15f, 7f, -7f);
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
                }
                if(Input.GetKeyDown(KeyCode.RightArrow)){
                    horizontal++;
                    if(horizontal>=4){horizontal=0;}
                }
        }
        if (Input.GetKeyDown(KeyCode.Z)&&electricBox.ReturnDoorLock())
        {
            UiObject.SetActive(true);
            UiText.text="방향키로 조작하시오.";
            StartCoroutine(ExecuteAfterDelayText(3f)); 
            isFixed = !isFixed;
            // 상태에 따라 플레이어 제어 여부를 조절
            if (isFixed)
            {
                // 특정 위치로 이동
                player.transform.position = new Vector3(354.2f, 1f, 424f);

                // 특정 회전값으로 설정
                player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                camera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

                // 플레이어의 움직임을 차단
                player.GetComponent<MouseLookScript>().enabled = false;
                player.GetComponent<PlayerMovementScript>().enabled = false;
                
            }
            else
            {   
                // 플레이어의 움직임을 다시 활성화
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
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
        UiObject.SetActive(false);
        
    }
    
    
 }

