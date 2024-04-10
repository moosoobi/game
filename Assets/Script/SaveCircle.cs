using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCircle : MonoBehaviour
{

    public GameObject Save;
    public PlayerHp playerhp;
    public int stage;
    public MusicStart MUSIC;
    


 
    


    void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player")){
                if(MUSIC){MUSIC.Clear=true;}
                playerhp.stage=stage;
                playerhp.PlayerCurHp=300f;
                playerhp.UpdateHealth(0);
                Save.SetActive(true);
                gameObject.SetActive(false);
                
            }
        
        
    }
}
