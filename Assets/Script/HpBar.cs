using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public int health;
    public int maxhealth;
    public Image[] hearts;

    void Start()
    {
        health=5;
        maxhealth=5;
        
    }
    public void healthminus(){health--;}
    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<maxhealth;i++){
            if(i<health){
                hearts[i].color=new Color32(255,255,255,255);
            }else{ hearts[i].color=new Color32(255,255,255,22);}
        }
        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack")){
            health--;
            if(health<=0){
                Debug.Log("게임 종료");
            }
        }
    }

}
