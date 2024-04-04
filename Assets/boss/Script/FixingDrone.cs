using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixingDrone : MonoBehaviour
{
    public Animator DroneAni;
    public GameObject Boss;
    public float moveSpeed = 5f;
    public bool Move=true;
    public bool first=true;
    void Start()
    {
        Boss=GameObject.FindGameObjectWithTag("BossBulletSpawn");
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Move){
            Vector3 directionToBoss = (Boss.transform.position - transform.position).normalized;
            directionToBoss.y=0;
            transform.Translate(directionToBoss * moveSpeed * Time.deltaTime*-1);
            Quaternion targetRotation = Quaternion.LookRotation(-directionToBoss);
            transform.rotation = targetRotation;
        }
        float distanceToBoss = Vector3.Distance(transform.position, Boss.transform.position);
        if (distanceToBoss <= 10.0f)
        {
            Move=false;
            if(first){DroneAni.Play("fixing_fix", 0, 0.0f);first=false;}
            
            
        }
        
    }
}
