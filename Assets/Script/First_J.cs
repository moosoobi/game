using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class First_J : MonoBehaviour
{
    
    public Animator J=null;
    public Animator P=null;

    public GameObject Tv_On;

    public AudioSource Tv_Off;

    public DialogueManager Dia;

    public bool first=true;
    public bool second=true;

    public TextMeshProUGUI dialogueText; // 대화 내용을 표시할 UI 텍스트
    public string[] dialogues; // 대화 내용을 담은 배열
    public float dialogueInterval = 3f; // 대화 간격 (3초)

    private int currentDialogueIndex = 0; // 현재 대화 인덱스

    void Start()
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
            StartCoroutine(StartConversation());
        }
    }

    IEnumerator StartConversation()
    {
        Dia.StartConversation();
        while (currentDialogueIndex < dialogues.Length)
        {
            // 대화 내용을 UI에 표시
            dialogueText.text = dialogues[currentDialogueIndex];

            // 대화 간격만큼 기다린 후 다음 대화로 넘어감
            yield return new WaitForSeconds(dialogueInterval);

            // 다음 대화로 인덱스 증가
            currentDialogueIndex++;
        }

        Dia.EndDialogue();
        J.enabled=false;
    }
    private IEnumerator Camera()
    {

        yield return new WaitForSeconds(5.0f);
        P.enabled=false;
        J.Play("J_Walk", 0, 0.0f);
        
        
    }
    /*
    private IEnumerator TvOff()
    {

    }
    */

}
