using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    public RectTransform uiRectTransform;
    public GameObject JackCoke;
    public GameObject JackCokeMouseOver;
    public GameObject Xrated;
    public GameObject XratedMouseOver;
    public GameObject Mojito;
    public GameObject MojitoMouseOver;
    public GameObject Blue;
    public GameObject BlueMouseOver;
    public GameObject Kahlua;
    public GameObject KahluaMouseOver;
    public GameObject Espresso;
    public GameObject EspressoMouseOver;
    public GameObject Black;
    public GameObject BlackMouseOver;
    public GameObject Tequila;
    public GameObject TequilaMouseOver;
    public GameObject Illegal;
    public GameObject IllegalMouseOver;
    public GameObject White;
    public GameObject WhiteMouseOver;
    public GameObject Peach;
    public GameObject PeachMouseOver;
    public GameObject Rusty;
    public GameObject RustyMouseOver;
    public GameObject AllClear;
    public GameObject AllClearOver;
    public float moveSpeed = 5f;
    public Cart cart;


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
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(1);
            }
            
        }else{
            JackCoke.SetActive(true);
            JackCokeMouseOver.SetActive(false);
        }
        if(currentX>-109f&&currentX<0f&&currentY>97f&&currentY<222f){
            Xrated.SetActive(false);
            XratedMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(2);
            }
            
        }else{
            Xrated.SetActive(true);
            XratedMouseOver.SetActive(false);
        }
        if(currentX>22f&&currentX<128f&&currentY>97f&&currentY<222f){
            Mojito.SetActive(false);
            MojitoMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(3);
            }
            
        }else{
            Mojito.SetActive(true);
            MojitoMouseOver.SetActive(false);
        }
        if(currentX>150f&&currentX<250f&&currentY>97f&&currentY<222f){
            Blue.SetActive(false);
            BlueMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(4);
            }
            
        }else{
            Blue.SetActive(true);
            BlueMouseOver.SetActive(false);
        }
        if(currentX>-234f&&currentX<-130f&&currentY>-61f&&currentY<66f){
            Kahlua.SetActive(false);
            KahluaMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(5);
            }
            
        }else{
            Kahlua.SetActive(true);
            KahluaMouseOver.SetActive(false);
        }
        if(currentX>-109f&&currentX<0f&&currentY>-61f&&currentY<66f){
            Espresso.SetActive(false);
            EspressoMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(6);
            }
            
        }else{
            Espresso.SetActive(true);
            EspressoMouseOver.SetActive(false);
        }
        if(currentX>22f&&currentX<128f&&currentY>-61f&&currentY<66f){
            White.SetActive(false);
            WhiteMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(7);
            }
            
        }else{
            White.SetActive(true);
            WhiteMouseOver.SetActive(false);
        }
        if(currentX>150f&&currentX<250f&&currentY>-61f&&currentY<66f){
            Tequila.SetActive(false);
            TequilaMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(8);
            }
            
        }else{
            Tequila.SetActive(true);
            TequilaMouseOver.SetActive(false);
        }
        if(currentX>-234f&&currentX<-130f&&currentY>-213f&&currentY<-83f){
            Black.SetActive(false);
            BlackMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(9);
            }
            
        }else{
            Black.SetActive(true);
            BlackMouseOver.SetActive(false);
        }
        if(currentX>-109f&&currentX<0f&&currentY>-213f&&currentY<-83f){
            Illegal.SetActive(false);
            IllegalMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(10);
            }
            
        }else{
            Illegal.SetActive(true);
            IllegalMouseOver.SetActive(false);
        }
        if(currentX>22f&&currentX<128f&&currentY>-213f&&currentY<-83f){
            Peach.SetActive(false);
            PeachMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(11);
            }
            
        }else{
            Peach.SetActive(true);
            PeachMouseOver.SetActive(false);
        }
        if(currentX>150f&&currentX<250f&&currentY>-213f&&currentY<-83f){
            Rusty.SetActive(false);
            RustyMouseOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AddItem(12);
            }
            
        }else{
            Rusty.SetActive(true);
            RustyMouseOver.SetActive(false);
        }
        if(currentX>44f&&currentX<150f&&currentY>-336f&&currentY<-314f){
            AllClear.SetActive(false);
            AllClearOver.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                cart.AllClear();
            }
            
        }else{
            AllClear.SetActive(true);
            AllClearOver.SetActive(false);
        }
        
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        // 입력에 따라 이동 방향 설정
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);

        // 현재 anchoredPosition 가져오기
        Vector2 currentPosition = uiRectTransform.anchoredPosition;

        // 입력에 따라 이동한 위치 계산
        Vector2 newPosition = currentPosition + moveDirection*moveSpeed * Time.deltaTime;

        // 새로 계산된 위치로 anchoredPosition 설정
        uiRectTransform.anchoredPosition = newPosition;
        
    }
    public void Registor(string Drink){

    }
}
