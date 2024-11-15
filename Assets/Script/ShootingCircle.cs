using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingCircle : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI QuestText;

    public AudioSource QuestSound;

    public bool Active=false;
    public Dummy Dummy1;
    public Dummy Dummy2;
    public Dummy Dummy3;

    public void Shoot(){
        
        Text.text="마네킹의 머리 가슴 배를 사격하십시오.";
        StartCoroutine(ChangeColor());
        Dummy1.Active=true;
        Dummy2.Active=true;
        Dummy3.Active=true;
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
        if(Active){
            if (other.CompareTag("Player")){
                Shoot();
                Active=false;
            }
        }
        
    }

}
