using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBody : MonoBehaviour
{

    public float explosionRadius = 5f; // 폭발 범위
    public bool Detect=false;
    public GameObject effect;

    void Update()
    {
        if(Detect){Detect=false;StartCoroutine(ExplodeAfterDelay());}
    }

    private IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 5초 후에 폭발

        // 수류탄 주변에 있는 적을 감지합니다.
        DetectEnemies();
        //effect.SetActive(true);
        // 수류탄을 제거합니다.
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void DetectEnemies()
    {
        // 수류탄 주변에 있는 적을 감지합니다.
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // 감지된 적에게 데미지를 입힙니다.
        foreach (Collider collider in colliders)
        {
            
            if(collider.name.Contains("Blue")){collider.GetComponent<Leg2RobotBlue>().FakeBody1(gameObject);}
            if(collider.name.Contains("Red")){collider.GetComponent<Leg2RobotRed>().FakeBody1(gameObject);;}
            if(collider.name.Contains("4leg")){collider.GetComponent<Leg4Robot>().FakeBody1(gameObject);;}
            
        }
    }
}


