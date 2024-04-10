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
    public AudioSource EnemyHittingSound;
    public Animator DroneAni=null;
    public EnemyDeath EnemyDeath;
    public GameObject DroneSlow;

    public int Hp=5;

    public bool Die=false;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(!Die){
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

            if(Hp<=0){
                    Die=true;
                    StartCoroutine(Death());
            }
        }
        
    }
    private IEnumerator Death()
    {
        DroneAni.Play("Death", 0, 0.0f);
        EnemyDeath.Death();
        DroneSlow.SetActive(false);
        SpeedUp();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        
        
    }
    public void SpeedUp(){
        gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
        
        gun.walkingSpeed=3;
        gun.runningSpeed=10;
        player.GetComponent<PlayerMovementScript>().currentSpeed=3;
        DroneSlow.SetActive(false);
    }
    public void SlowDown(){
        DroneSlow.SetActive(true);
        gun=GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>();
        gun.walkingSpeed=1;
        gun.runningSpeed=1;
        player.GetComponent<PlayerMovementScript>().currentSpeed=1;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            Hp-=1;
            EnemyHittingSound.Play();
        }
    }
}
