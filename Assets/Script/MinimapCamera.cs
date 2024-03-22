using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // 플레이어의 위치를 정확히 따라가기
            transform.position = new Vector3(player.position.x, transform.position.y, player.transform.position.z);
        }
    }
}
