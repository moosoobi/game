using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cart : MonoBehaviour
{

    public string[] productNames;
    public int[] productPrices;
    public int index=0;
    public int TotalPrice=0;
    public TextMeshProUGUI CartName;
    public TextMeshProUGUI CartPrice;
    public TextMeshProUGUI OrderAmount;
    public TextMeshProUGUI OrderTotalPrice;
    public GameObject player;
    public GameObject Cursor;
    public GameObject KioskUi;
    public GameObject SuccessDoor;

    public TextMeshProUGUI QuestText;
    public TextMeshProUGUI Text2;//questtext
    public AudioSource StoneDoor;
    public AudioSource RadioSound;
    public string[] dialogue;
    public string[] dialogue2;
    public int curResponseTracker=0;
    public int curResponseTracker2=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public bool isTalking2=false;
    private bool talked=false;
    public bool Clear=false;
    public GunInventory guninventory;
    public GameObject InsertCard;
    public GameObject BarCamera;
    public SuccessDoor SuccessDoorScript;


    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
            ContinueConversation();          
        }
        if(Input.GetMouseButtonDown(0)&&isTalking2==true){
            ContinueConversation2();          
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
            EndDialogue();
        }
        if(Input.GetMouseButtonDown(0)&&curResponseTracker2==dialogue2.Length){
            EndDialogue2();
        }
        if(Clear&&guninventory.currneguniscard()&&Input.GetMouseButtonDown(0)){
            guninventory.NegativeCard();
            guninventory.ChangeWeapon1();
            KioskUi.SetActive(false);
            BarCamera.SetActive(true);
            InsertCard.SetActive(false);
            StartCoroutine(Camera());
            Clear=false;
        }
    }
    private IEnumerator Camera()
    {
        SuccessDoorScript.Success();
        StoneDoor.Play();
        yield return new WaitForSeconds(3.0f);
        BarCamera.SetActive(false);
        StartConversation2();
    }
    public void AddItem(int number)
    {
        if(index==4){}
        else{
            if(number==1){
            productNames[index]="jack coke";
            productPrices[index]=80000;
            }else if(number==2){
                productNames[index]="Xrated tonic";
                productPrices[index]=90000;
            }else if(number==3){
                productNames[index]="mojito";
                productPrices[index]=70000;
            }
            else if(number==4){
                productNames[index]="blue hawaii";
                productPrices[index]=70000;
            }
            else if(number==5){
                productNames[index]="kahlua milk";
                productPrices[index]=85000;
            }
            else if(number==6){
                productNames[index]="Espresso martini";
                productPrices[index]=120000;
            }
            else if(number==7){
                productNames[index]="white russian";
                productPrices[index]=85000;
            }
            else if(number==8){
                productNames[index]="Tequlia sunrise";
                productPrices[index]=75000;
            }
            else if(number==9){
                productNames[index]="black russian";
                productPrices[index]=80000;
            }
            else if(number==10){
                productNames[index]="Illegal";
                productPrices[index]=100000;
            }
            else if(number==11){
                productNames[index]="peach crush";
                productPrices[index]=65000;
            }
            else if(number==12){
                productNames[index]="rusty nail";
                productPrices[index]=80000;
            }
            index=index+1;
            DisplayShoppingCart();
        }
        
    }

    public void DisplayShoppingCart()
    {
        CartName.text = string.Join("\n", productNames);
        string productPrice = productPrices[index-1].ToString();
        CartPrice.text += productPrice;
        CartPrice.text += "\n";
        OrderAmount.text=index.ToString();
        TotalPrice+=productPrices[index-1];
        OrderTotalPrice.text=TotalPrice.ToString();

    }
    public void Check(){
        if(productNames[0]=="Espresso martini"&&productNames[1]=="Xrated tonic"&&productNames[2]=="Illegal"&&productNames[3]=="Tequlia sunrise"){
            Cursor.SetActive(false);
            Clear=true;
            InsertCard.SetActive(true);

            
        }else{
            Cursor.SetActive(false);
            KioskUi.SetActive(false);
            player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
            StartConversation();
        }

    }
    public void QuestActive(){
        Text2.text="천장에 있는 동그란 전등을 사격하라.";
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
    public void AllClear(){
        index=0;
        productNames[0]="";
        productNames[1]="";
        productNames[2]="";
        productNames[3]="";
        productPrices[0]=0;
        productPrices[1]=0;
        productPrices[2]=0;
        productPrices[3]=0;
        CartPrice.text="";
        CartName.text="";
        OrderAmount.text="";
        OrderTotalPrice.text="";
        TotalPrice=0;
       
    }
    public void StartConversation(){
        isTalking=true;
        curResponseTracker=0;
        dialogueUI.SetActive(true);
        npcName.text="주인공";
        npcDialogueBox.text=dialogue[0];
        

    }
    public void ContinueConversation(){
            curResponseTracker++;
            if(curResponseTracker>dialogue.Length){
                curResponseTracker=dialogue.Length;
            }
            else if(curResponseTracker<dialogue.Length)
            {
                npcDialogueBox.text=dialogue[curResponseTracker];
            }
    }
    public void EndDialogue(){
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
    }
    public void StartConversation2(){
        isTalking2=true;
        curResponseTracker2=0;
        dialogueUI.SetActive(true);
        npcName.text="주인공";
        npcDialogueBox.text=dialogue2[0];
        

    }
    public void ContinueConversation2(){
            if(curResponseTracker2==1){
                npcName.text="J";
                RadioSound.Play();
            }
            curResponseTracker2++;
            if(curResponseTracker2>dialogue2.Length){
                curResponseTracker2=dialogue2.Length;
            }
            else if(curResponseTracker2<dialogue2.Length)
            {
                npcDialogueBox.text=dialogue2[curResponseTracker2];
            }
    }
    public void EndDialogue2(){
        curResponseTracker2=0;
        isTalking2=false;
        dialogueUI.SetActive(false);
        QuestActive();
        player.GetComponent<MouseLookScript>().enabled = true;
        player.GetComponent<PlayerMovementScript>().enabled = true;
    }
    public bool IsTalking(){return isTalking==false&&isTalking2==false;}
}
