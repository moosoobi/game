using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazer : MonoBehaviour
{
    public float rotationSpeed = 200f; // 프로펠러의 회전 속도
  

    void Update()
    {
        // 회전 속도에 따라 프로펠러를 회전시킴
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    
}
