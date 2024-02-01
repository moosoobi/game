using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class First_Bar : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public string Description;
    public TextMeshProUGUI QuestText;

    public void QuestActive(){
        Text.text=Description;
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor(){
        for(int i=0;i<3;i++){
            QuestText.color=new Color32(229,255,0,255);
            yield return new WaitForSeconds(0.5f);
            QuestText.color=new Color32(0,222,255,255);
            yield return new WaitForSeconds(0.5f);
        }
    }
    //무전기능구현해보자
}
