using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Material On_Material;
    public Material Off_Material;
    public Mannequin mannequin;
    public AudioSource ShutDown;
    public GameObject side;
    public bool ifhit=false;
    public bool Active=false;

    
    private void OnTriggerEnter(Collider other)
    {
        if(Active){
            GetComponent<Renderer>().material=Off_Material;
            if(side)side.GetComponent<Renderer>().material=Off_Material;
            ShutDown.Play ();
            
            ifhit=true;
            mannequin.hit();
        }
        

    }
    private IEnumerator ChangeMaterialAfterDelay()
    {
        // 3초 대기
        yield return new WaitForSeconds(3f);
        if(side)side.GetComponent<Renderer>().material=On_Material;
        GetComponent<Renderer>().material=On_Material;
    }
    public bool returnhit(){return ifhit;}
    
}
