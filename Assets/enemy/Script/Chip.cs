using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){if(player){player.GetComponent<PlayerMovementScript>().UpChip();}gameObject.SetActive(false);}
    }
}
