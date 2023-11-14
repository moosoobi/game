using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int,string[]>talkData;


    void Awake()
    {
        talkData=new Dictionary<int,string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000,new string[]{"안녕?","이 곳에 처음 왔구나?"});
        talkData.Add(100,new string[]{"평범한 나무상자다."});
    }

    public string GetTalk(int id,int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
