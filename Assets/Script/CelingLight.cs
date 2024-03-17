using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelingLight : MonoBehaviour
{
    public AudioSource EnemyDeathSound;
    public Light[] light;
    public Material newMaterial;
    public bool first=true;
    public GameObject CelingLight1;
    public GameObject CelingLight2;
    public GameObject CelingLight3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            if(first){
                EnemyDeathSound.Play();
                first=false;
                for(int i=0;i<3;i++){
                    light[i].enabled = false;
                }
                Renderer rend1 = CelingLight1.GetComponent<Renderer>();
                rend1.material = newMaterial;
                Renderer rend2 = CelingLight2.GetComponent<Renderer>();
                rend2.material = newMaterial;
                Renderer rend3 = CelingLight3.GetComponent<Renderer>();
                rend3.material = newMaterial;
            }
            
        }
    }
}
