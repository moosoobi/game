using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_J : MonoBehaviour
{
    
    public Animator J=null;

    public GameObject Tv_On;

    public AudioSource Tv_Off;

    public DialogueManager Dia;

    public bool first=true;
    public bool second=true;

    void Start()
    {
        J.Play("J_Walk", 0, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z == 432f&&first)
        {
            first=false;
            Tv_On.SetActive(false);
            Tv_Off.Play();
        }
        if (transform.position.z == 427f&&second)
        {
            second=false;
            Dia.StartConversation();
        }
    }

    /*
    private IEnumerator TvOff()
    {

    }
    */

}
