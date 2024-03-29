using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    
    public GunScript gun;
    public bool z=true;
    public float DetectRange;
    public GameObject player;
    public float raycastDistance ;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized *raycastDistance, Color.red);
        if(Vector3.Distance(transform.position, player.transform.position)<DetectRange){
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, player.transform.position- transform.position, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.name=="Player"){
                    SlowDown();
                    z=false;
                    
                }else{
                    if(!z){SpeedUp();z=true;}
                }
            }   
        }
        else{
            
                    if(!z){SpeedUp();z=true;}
                
        }
    }
    public void SpeedUp(){
        gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
        gun.walkingSpeed=3;
        gun.runningSpeed=10;
    }
    public void SlowDown(){
        
        gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
        gun.walkingSpeed=1;
        gun.runningSpeed=1;
    }
}
