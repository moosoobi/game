using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg4Bullet : MonoBehaviour
{
    

    public float speed = 10f; // 총알 이동 속도

    void Update()
    {
        // 총알을 앞으로 이동
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Box Volume (2)"){}
        else{
            
            Destroy(gameObject);
        }
    }
 

}
