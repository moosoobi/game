using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public SceneController Scene; 
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Scene.LoadNextScene();
        }
    }

}
