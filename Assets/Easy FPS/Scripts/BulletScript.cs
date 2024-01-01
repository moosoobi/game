using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	void Start()
    {
        // 총알을 시작할 때 바로 움직이도록 추가
        MoveBullet();
    }

    // 총알을 움직이는 속도
    private float maxSpeed = 10.0f;

    // 총알이 움직이는 방향으로 이동하는 함수
    private void MoveBullet()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * maxSpeed;
    }

    // 이하 코드는 변경되지 않았습니다.
    private void OnTriggerEnter(Collider other)
    {
        if (decalHitWall)
        {
            if (other.CompareTag("LevelPart"))
            {
                Instantiate(decalHitWall, transform.position + transform.forward * floatInfrontOfWall, Quaternion.LookRotation(transform.forward));
                Destroy(gameObject);
            }
            else if (other.CompareTag("Dummie"))
            {
                Instantiate(bloodEffect, transform.position, Quaternion.LookRotation(transform.forward));
                Destroy(gameObject);
            }
        }
    }

}
