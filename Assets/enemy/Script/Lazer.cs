using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{


    public GameObject Player;
    public GameObject prefabToClone;

    public bool IfHit=false;

    public float raycastDistance = 0.2f;


    void Start()
    {
        

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up*-1.0f, out hit, raycastDistance))
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.name=="Player"){
                Player=GameObject.FindGameObjectWithTag("Player");
                if(Player){
                    Player.GetComponent<PlayerHp>().UpdateHealth(-10f);
                    
                }
                }
        }
        else
        {
            GameObject clone = Instantiate(prefabToClone, transform.position+transform.up*-0.2f, transform.rotation);
        }
        Invoke("DestroyBullet", 1f);
        
    }
    void DestroyBullet()
    {
        // 총알을 파괴
        Destroy(gameObject);
    }


}
