using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEle : MonoBehaviour
{
    public bool Clear=false;
    public bool zzz=false;
    public float maxHeight;
    public GameObject Ele;
    public GameObject player;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if(zzz&&Clear&&Ele.transform.position.y < maxHeight){
            
            Ele.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            player.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
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
