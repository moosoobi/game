using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;
    public float Y;


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            
            transform.position = new Vector3(player.position.x, Y, player.transform.position.z);
            transform.rotation = Quaternion.Euler(0f, player.eulerAngles.y+90f, 0f);
        }
    }
}
