using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg4Bullet : MonoBehaviour
{
    

    public float speed = 10f; // 총알 이동 속도
    public GameObject player;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        Invoke("DeactivateAfterDelay", 10f);
        
    }
    void DeactivateAfterDelay()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        // 총알을 앞으로 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Box Volume (2)"){}
        if (other.gameObject.name == "Player"){player.GetComponent<PlayerHp>().UpdateHealth(-10f);}
        
    }
 

}
