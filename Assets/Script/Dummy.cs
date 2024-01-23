using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Material On_Material;
    public Material Off_Material;
    public AudioSource ShutDown;
    public ShootingQuest shoot;

    
    void Awake()
    {
        shoot=GameObject.FindGameObjectWithTag("QuestManager").GetComponent<ShootingQuest>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material=Off_Material;
        ShutDown.Play ();
        StartCoroutine(ChangeMaterialAfterDelay());
        shoot.BulletHitTarget();
    }
    private IEnumerator ChangeMaterialAfterDelay()
    {
        // 3초 대기
        yield return new WaitForSeconds(3f);
        GetComponent<Renderer>().material=On_Material;
    }
    
}
