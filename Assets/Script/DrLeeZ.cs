using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrLeeZ : MonoBehaviour
{
    public DrLee dr;
    public bool first=true;
    public GameObject player;
    public GameObject RoadEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if(first){
                RoadEnemy.SetActive(false);
                first=false;
                dr.Approch=true;
                player.GetComponent<MouseLookScript>().enabled = false;
                player.GetComponent<PlayerMovementScript>().enabled = false;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0,0);
                


            }
            
        }
    }
}
