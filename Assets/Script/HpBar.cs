using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    static public int health;
    public int maxhealth;
    public Image[] hearts;

    void Start()
    {
        health=2;
        maxhealth=5;
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<maxhealth;i++){
            if(i<health){
                hearts[i].color=new Color32(255,255,255,255);
            }else{ hearts[i].color=new Color32(255,255,255,22);}
        }
        
    }
  
    void OnCollisionEnter(Collision enemy)
    {
        HpBar.health--;
        if(HpBar.health<=0){
            Debug.Log("게임 종료");
        }
    }
}
