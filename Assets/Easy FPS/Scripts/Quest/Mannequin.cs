using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    public Dummy top;
    public Dummy middle;
    public Dummy bottom;
    public ShootingQuest shoot;
    public bool tophit=false;
    public bool middlehit=false;
    public bool bottomhit=false;


    public void hit(){
        tophit=top.returnhit();
        middlehit=middle.returnhit();
        bottomhit=bottom.returnhit();
        if(tophit==true&&middlehit==true&&bottomhit==true){shoot.BulletHitTarget();}
    }

}
