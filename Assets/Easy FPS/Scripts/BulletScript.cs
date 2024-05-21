using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    
	public GameObject bloodEffect;
    public bool Upgrade;
    public float maxSpeed = 15.0f;

	void Start()
    {

        Upgrade= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().Upgrade;
        if(Upgrade){maxSpeed=60f;}
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

            //Debug.Log(other.name);
            if(other.CompareTag("Enemy"))
            {
                Instantiate(bloodEffect, transform.position, Quaternion.LookRotation(transform.forward));
                Destroy(gameObject);
            }else if(other.CompareTag("Volume")){

            }else if(other.name == "Bone001"){

            }else if(other.name == "BoxVolumn"){

            }else if(other.name == "ConnerBg"){

            }else if(other.name == "Box009"){

            }else if(other.name == "DrLeeZ"){

            }
            else if(other.name == "slidingDoor_bar"){

            }
            else if(other.name == "BarBg"){

            }
            else if(other.name == "Leg2"){

            }else if(other.name == "barentrance_collider"){

            }else if(other.name == "BarBarrier"){

            }else if(other.name == "Sliding_z"){

            }
            else{
                Debug.Log(other.name);
                Destroy(gameObject);
            }
    }

}
