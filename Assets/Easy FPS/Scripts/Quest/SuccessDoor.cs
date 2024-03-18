using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessDoor : MonoBehaviour
{
    public Animator myDoor=null;

    public void Success(){
        myDoor.Play("BarDoorOpen", 0, 0.0f);
    }
}
