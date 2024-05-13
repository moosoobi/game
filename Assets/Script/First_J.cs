using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class First_J : MonoBehaviour
{
    
    public Animator J=null;
    public Animator P=null;

    public GameObject Tv_On;
    public GameObject Hp;
    public GameObject Inven;
    public GameObject Quest;
    public GameObject Opening;
    public AudioSource RoomBg;
    public AudioSource Tv_Off;

    public DialogueManager Dia;

    public bool first=true;
    public bool second=true;

    public TextMeshProUGUI dialogueText; // 대화 내용을 표시할 UI 텍스트
    public string[] dialogues; // 대화 내용을 담은 배열
    public float dialogueInterval = 3f; // 대화 간격 (3초)

    private int currentDialogueIndex = 0; // 현재 대화 인덱스
    

    public GameObject Help;
    public TextMeshProUGUI HelpText;
    
    void Start()
    {
        //Quest.SetActive(true);
        Hp.SetActive(true);
        Starting();
        Inven.SetActive(true);
        RoomBg.Play();
    }
    public void Starting()
    {
        P.enabled=true;
        P.Play("CameraMoving", 0, 0.0f);
        StartCoroutine(Camera());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z == 432f&&first)
        {
            first=false;
            Tv_On.SetActive(false);
            Tv_Off.Play();
        }
        if (transform.position.z == 427f&&second)
        {
            second=false;
            Dia.StartConversation();
        }
    }
    private IEnumerator Camera()
    {

        yield return new WaitForSeconds(5.0f);
        P.enabled=false;
        J.Play("J_Walk", 0, 0.0f);
        yield return new WaitForSeconds(7.5f);
        J.SetTrigger("talk");


    }
    /*
    private IEnumerator TvOff()
    {

    }
    */

}
