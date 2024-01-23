using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        
        switchStates = new int[switches.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(zzzz){
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isFixed = !isFixed;

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

                if(Input.GetKey(KeyCode.UpArrow)){
                    switches[horizontal].transform.rotation = Quaternion.Euler(-40f, 0f, 0f);
                }
                if(Input.GetKey(KeyCode.DownArrow)){
                    switches[horizontal].transform.rotation = Quaternion.Euler(40f, 40f, 0f);
                }
                if(Input.GetKey(KeyCode.LeftArrow)){
                    horizontal++;
                    if(horizontal>=4){horizontal=0;}
                }
                if(Input.GetKey(KeyCode.RightArrow)){
                    horizontal++;
                    if(horizontal>=4){horizontal=0;}
                }
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
    private void OnTriggerStay(Collider other)
    {
        
        zzzz=true;
        StartCoroutine(ExecuteAfterDelay(3.0f));
        
    }
    
    
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        zzzz=false;
    }
 }

