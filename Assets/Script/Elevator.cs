using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elevator : MonoBehaviour
{
    public Animator myDoor=null;

    public float maxHeight = 247f;
    public float moveSpeed = 2f;

    public bool movingUp = false;
    public bool First=true;
    public bool zzz=false;
    public bool clear=false;
    
    public GameObject player;
    public GameObject Click;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;

    public AudioSource Arrived;

    
    

    void Update()
    {
        if (movingUp && transform.position.y < maxHeight)
        {
            if(First){
                    First=false;
                    StartCoroutine(StartConversation());
            }
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            player.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (movingUp && transform.position.y > maxHeight){
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
            myDoor.Play("EleOpen", 0, 0.0f);
            Arrived.Play();
            movingUp=false;
        }


    }
    /*
    void OnTriggerEnter(Collider other)
    {
            zzz=true;
            if (other.CompareTag("Player")){
                movingUp=true;
                if(First){
                    First=false;
                    StartCoroutine(StartConversation());
                }
            }
        
        
    }
    */
    IEnumerator StartConversation()
    {
        Click.SetActive(false);
        yield return new WaitForSeconds(10.0f);
        dialogueUI.SetActive(true);
        npcName.text=" ";
        npcDialogueBox.text="…항상 아래에서 위를 쳐다보기만 했었는데";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="… …";
        yield return new WaitForSeconds(3.0f);
        npcDialogueBox.text="위에서 내려다 보는 도시는 꽤 아름답네";
        yield return new WaitForSeconds(3.0f);
        Click.SetActive(true);
        dialogueUI.SetActive(false);


        
    }


}
