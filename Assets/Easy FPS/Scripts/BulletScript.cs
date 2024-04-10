using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    
	public GameObject bloodEffect;
    public bool Upgrade;
    public float maxSpeed = 15.0f;

	void Start()
    {
        Upgrade= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().Upgrade;
        MoveBullet();
        Invoke("DeactivateAfterDelay", 10f);
    }
    void DeactivateAfterDelay()
    {
        Destroy(gameObject);
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
            }else if(other.CompareTag("Volume")){

            }else if(other.name == "Bone001"){

            }else if(other.name == "ConnerBg"){

            }
            else{
                
                Destroy(gameObject);
            }
    }

}
