using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator myDoor=null;

    public float maxHeight = 247f;
    public float moveSpeed = 2f;

    public bool movingUp = false;
    
    public GameObject player;
  

    // Update is called once per frame
    void Update()
    {
        if (movingUp && transform.position.y < maxHeight)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            player.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (movingUp && transform.position.y > maxHeight){
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
            myDoor.Play("EleOpen", 0, 0.0f);
            movingUp=false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player")){
                movingUp=true;
            }
        
        
    }
}
