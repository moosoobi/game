using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CelingLight : MonoBehaviour
{
    public AudioSource EnemyDeathSound;
    public Light[] light;
    public Material newMaterial;
    public Material newMaterial1;
    public bool first=true;
    public GameObject CelingLight1;
    public GameObject CelingLight2;
    public GameObject CelingLight3;
    public AudioSource BarBackground;
    public TextMeshProUGUI QuestText;
    public TextMeshProUGUI Text2;//questtext
    public GameObject stage2;
    public AudioSource QuestSound;

    public void LightOff()
    {
        
        if(first){
            EnemyDeathSound.Play();
            first=false;
            for(int i=0;i<3;i++){
                light[i].enabled = false;
            }
            Renderer rend1 = CelingLight1.GetComponent<Renderer>();
            rend1.material = newMaterial;
            Renderer rend2 = CelingLight2.GetComponent<Renderer>();
            rend2.material = newMaterial;
            Renderer rend3 = CelingLight3.GetComponent<Renderer>();
            rend3.material = newMaterial1;
            BarBackground.Stop();
            QuestActive();
            stage2.SetActive(false);
            
        }
        
    }
    public void QuestActive(){
        Text2.text="비밀통로로 가 에너지 증폭장치를 찾으십시오.";
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        QuestSound.Play();
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            LightOff();
            
        }
    }
}
