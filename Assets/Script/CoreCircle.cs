using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoreCircle : MonoBehaviour
{
    public EnergyCore core;
    public GameObject player;
    public bool Short=false;
    public Animator myDoor=null;
    public AudioSource DrawerOpen;
    public GameObject Guide;
    public GameObject Guide1;
    public TextMeshProUGUI Text2;//questtext
    public TextMeshProUGUI QuestText;
    public AudioSource QuestSound;

    public void QuestActive(){
        Text2.text="에너지 증폭장치를 파괴하십시오.";
        Guide1.SetActive(true);
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor(){
        QuestSound.Play();
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0,0);
            player.GetComponent<PlayerMovementScript>().enabled = false;
            core.Circle=true;
            Guide.SetActive(false);
            Invoke("Deactivate", 10.0f);
            
            if(Short){
                myDoor.Play("DoorOpen", 0, 0.0f);
                if (DrawerOpen)
                    DrawerOpen.Play ();
                Guide.SetActive(false);
                Invoke("Deactivate", 10.0f);
                QuestActive();
            }
            
        }
        
        
    }
    void Deactivate()
    {
        Guide1.SetActive(false);
    }
}
