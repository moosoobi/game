using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹을 연결할 변수
    public GameObject bulletPos;
    public Light muzzleFlash;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을 때
        {
            
            Shoot(); // 총알 생성 함수 호출
        }
    }

    void Shoot()
    {
        
        // 총알을 생성하고, 생성된 총알의 위치와 회전을 현재 총의 위치와 회전으로 설정
        GameObject bullet = Instantiate(bulletPrefab, bulletPos.transform.position, bulletPos.transform.rotation);
       
    }
    IEnumerator DisableMuzzleFlash()
    {
        // 0.1초 후에 총구에서 빛 비활성화
        yield return new WaitForSeconds(0.1f);
        if (muzzleFlash != null)
        {
            muzzleFlash.enabled = false;
        }
    }
}
