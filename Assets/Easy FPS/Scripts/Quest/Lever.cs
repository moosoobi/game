using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Lever : MonoBehaviour
{
    public GameObject[] switches;
    public int[] switchStates;
    public int horizontal=0;
    public int vertical=0;
    private bool isFixed = false;
    public GameObject player;
    public GameObject camera;
    public bool zzzz=false;
    public TextMeshProUGUI Text;
    public GameObject text1;
    
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
                Text.text="성공!";
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isFixed = !isFixed;
            text1.SetActive(true);
            // 상태에 따라 플레이어 제어 여부를 조절
            if (isFixed)
            {
                // 특정 위치로 이동
                player.transform.position = new Vector3(500f, 0.6f, 501.5f);

                // 특정 회전값으로 설정
                player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                camera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

                // 플레이어의 움직임을 차단
                player.GetComponent<MouseLookScript>().enabled = false;
                player.GetComponent<PlayerMovementScript>().enabled = false;
                
            }
            else
            {   
                text1.SetActive(false);
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
    
    
    
 }

