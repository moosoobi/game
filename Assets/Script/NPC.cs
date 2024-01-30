using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="NPC file", menuName="NPC Files Archive")]
public class NPC : ScriptableObject
{
    
    public string name;
    [TextArea(3,15)]
    public string[] dialogue;
    [TextArea(3,15)]
    public string[] dialogue2;
    [TextArea(3,15)]
    public string[] dialogue3;
    [TextArea(3,15)]
    public int stage=0;
    public void upstage(){stage++;}

   


}
