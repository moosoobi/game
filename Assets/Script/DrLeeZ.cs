using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrLeeZ : MonoBehaviour
{
    public DrLee dr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            dr.StartConversation();
        }
    }
}
