using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    
	public GameObject bloodEffect;
    private float maxSpeed = 15.0f;

	void Start()
    {
        StartCoroutine(BulletDestroy());
        MoveBullet();
    }


    // 총알이 움직이는 방향으로 이동하는 함수
    private void MoveBullet()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * maxSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {

            
            if(other.CompareTag("Enemy"))
            {
                Instantiate(bloodEffect, transform.position, Quaternion.LookRotation(transform.forward));
                Destroy(gameObject);
            }else{
                
                
            }
    }
    private IEnumerator BulletDestroy(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
