using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chip : MonoBehaviour
{
    public GameObject player;
    public GameObject ChipObj;
    public TextMeshProUGUI ChipText;
    public ChipText ChipTextScript;


    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        ChipObj=GameObject.FindGameObjectWithTag("ChipText");
        ChipText=GameObject.FindGameObjectWithTag("ChipText").GetComponent<TextMeshProUGUI>();
        ChipTextScript=GameObject.FindGameObjectWithTag("ChipText").GetComponent<ChipText>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            
            if(player){
                player.GetComponent<PlayerMovementScript>().UpChip();
            }
            ChipText.enabled=true;
            ChipText.text="칩셋획득: "+player.GetComponent<PlayerMovementScript>().ChipInt+" 개";
            ChipTextScript.Active();
            
            
            gameObject.SetActive(false);}
    }
}
