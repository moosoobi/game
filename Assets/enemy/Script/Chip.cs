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
        ChipTextScript=GameObject.FindGameObjectWithTag("ChipText").GetComponent<ChipText>();
        ChipText=ChipObj.GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        if(player.GetComponent<PlayerHp>().Die == true){gameObject.SetActive(false);}
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
