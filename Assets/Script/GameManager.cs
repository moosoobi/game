using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;


    public void Action(GameObject scanObj)
    {
        if(isAction){
            isAction=false;
        }
        else{
            isAction=true;
            scanObject=scanObj;
        }
        talkPanel.SetActive(isAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
