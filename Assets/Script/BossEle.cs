using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEle : MonoBehaviour
{
    public bool Clear=false;
    public bool zzz=false;
    public float maxHeight;
    public float minHeight;
    public GameObject Ele;
    public GameObject player;
    public GameObject Guide;
    public GameObject Circle;
    public float moveSpeed;


    void Start()
    {
        minHeight=Ele.transform.position.y;
    }
    void Update()
    {
        
        if(zzz&&Clear&&Ele.transform.position.y < maxHeight){
            Guide.SetActive(false);
            Circle.SetActive(false);
            Ele.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            player.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }else{
            if(Ele.transform.position.y > minHeight){
                Ele.transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")){
            zzz=true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            zzz=false;
        }
    }
}
