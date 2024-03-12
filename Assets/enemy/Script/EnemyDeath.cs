using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    
    public AudioSource EnemyDeath1;
    public AudioSource EnemyDeath2;

    public void Death(){
        EnemyDeath1.Play();
        EnemyDeath2.Play();
    }
}
