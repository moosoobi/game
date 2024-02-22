using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    public RectTransform uiRectTransform;
    public GameObject JackCoke;
    public GameObject JackCokeMouseOver;


    void Start()
    {
        uiRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {

        float currentX = uiRectTransform.anchoredPosition.x;
        float currentY = uiRectTransform.anchoredPosition.y;

        if(currentX>-234f&&currentX<-130f&&currentY>97f&&currentY<222f){
            JackCoke.SetActive(false);
            JackCokeMouseOver.SetActive(true);
            /*
            if (Input.GetMouseButtonDown(0))
            {

            }
            */
        }else{
            JackCoke.SetActive(true);
            JackCokeMouseOver.SetActive(false);
        }
        
    }
}
