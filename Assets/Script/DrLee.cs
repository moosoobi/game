using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrLee : MonoBehaviour
{
   
    public GameObject player;
    public string[] dialogue;
    public string[] dialogue1;
    public string[] dialogue2;
    public string[] dialogue3;
    public string[] dialogue4;
    public string[] dialogue5;
    public int curResponseTracker=0;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public GameObject dialogueUI;
    public bool isTalking=false;
    public int Stage=0;
    public int Chip;
    public int BuyInt=0;
    public bool Conversation=false;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI QuestText;
    public TextMeshProUGUI UiText;
    public GameObject UiObject;
    public GameObject ShopUi;
    public GameObject Cursur;
    public TextMeshProUGUI ChipIntUi;
    public bool Shopping;
    public bool Buying;
    public bool IfBuy=false;
    public float moveSpeed = 500f;
    public RectTransform uiRectTransform;
    public GameObject Emp;
    public GameObject EmpPick;
    public GameObject EmpDetail;
    public GameObject FakeBody;
    public GameObject FakeBodyPick;
    public GameObject FakeBodyDetail;
    public GameObject HealKit;
    public GameObject HealKitPick;
    public GameObject HealKitDetail;
    public GameObject Upgrade;
    public GameObject UpgradePick;
    public GameObject UpgradeDetail;
    public GameObject ChipSet;
    public GameObject ChipSetPick;
    public GameObject ChipSetDetail;
    public GameObject Buy;
    public GameObject EmpBuy;
    public GameObject FakeBodyBuy;
    public GameObject HealKitBuy;
    public GameObject UpgradeBuy;
    public GameObject ChipSetBuy;
    



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chip=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt;
        ChipIntUi.text=Chip.ToString();
        if(Input.GetMouseButtonDown(0)&&isTalking==true){
                
            ContinueConversation();          
        }
        if(Stage==0){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue.Length){
                EndDialogue();
            }
        }else if(Stage==1){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue1.Length){
                EndDialogue();
            }
        }else if(Stage==2){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue2.Length){
                EndDialogue();
            }
        }else if(Stage==3){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue3.Length){
                EndDialogue();
            }
        }else if(Stage==4){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue4.Length){
                EndDialogue();
            }
        }
        else if(Stage==5){
            if(Input.GetMouseButtonDown(0)&&curResponseTracker==dialogue5.Length){
                EndDialogue();
            }
        }
        if(Shopping){
            float currentX = uiRectTransform.anchoredPosition.x;
            float currentY = uiRectTransform.anchoredPosition.y;

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
            if(currentX>-540f&&currentX<-440f&&currentY>-340f&&currentY<-290f){
                if (Input.GetMouseButtonDown(0)){
                    Buy.SetActive(false);
                    Cursur.SetActive(false);
                    ShopUi.SetActive(false);
                    Shopping=false;
                    Buying=false;
                    if(!IfBuy){
                        Stage=4;
                        StartConversation();
                    }else{
                        Stage=5;
                        StartConversation();
                    }
                }
            }
            if(currentX>63f&&currentX<562f){
                if(currentY>-150f&&currentY<-70f){
                    ChipSetPick.SetActive(true);
                    ChipSetDetail.SetActive(true);
                    if (Input.GetMouseButtonDown(0)){
                        ChipSetBuy.SetActive(true);
                        Buy.SetActive(true);
                        BuyInt=0;
                        Shopping=false;
                        StartCoroutine(AfterBuying(0.1f));
                    }
            
                }else{
                    ChipSetPick.SetActive(false);
                    ChipSetDetail.SetActive(false);
                }
                if(currentY>-70f&&currentY<10f){
                    UpgradePick.SetActive(true);
                    UpgradeDetail.SetActive(true);
                    if (Input.GetMouseButtonDown(0)){
                        UpgradeBuy.SetActive(true);
                        Buy.SetActive(true);
                        BuyInt=1;
                        Shopping=false;
                        Buying=true;
                    }
                }else{
                    UpgradePick.SetActive(false);
                    UpgradeDetail.SetActive(false);
                }
                if(currentY>10f&&currentY<90f){
                    HealKitPick.SetActive(true);
                    HealKitDetail.SetActive(true);
                    if (Input.GetMouseButtonDown(0)){
                        HealKitBuy.SetActive(true);
                
                        Buy.SetActive(true);
                        BuyInt=2;
                        Shopping=false;
                        Buying=true;
                    }
                }else{
                    HealKitPick.SetActive(false);
                    HealKitDetail.SetActive(false);
                }
                if(currentY>90f&&currentY<170f){
                    FakeBodyPick.SetActive(true);
                    FakeBodyDetail.SetActive(true);
                    if (Input.GetMouseButtonDown(0)){
                        FakeBodyBuy.SetActive(true);
                        Buy.SetActive(true);
                        BuyInt=3;
                        Shopping=false;
                        Buying=true;
                    }
                }else{
                    FakeBodyPick.SetActive(false);
                    FakeBodyDetail.SetActive(false);
                }
                if(currentY>170f&&currentY<2500f){
                    EmpPick.SetActive(true);
                    EmpDetail.SetActive(true);
                    if (Input.GetMouseButtonDown(0)){
                        EmpBuy.SetActive(true);
                        Buy.SetActive(true);
                        BuyInt=4;
                        Shopping=false;
                        Buying=true;
                    }
                }else{
                    EmpPick.SetActive(false);
                    EmpDetail.SetActive(false);
                }

            }
        }
        if(Buying){
            float currentX = uiRectTransform.anchoredPosition.x;
            float currentY = uiRectTransform.anchoredPosition.y;

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
            if(currentY>-142f&&currentY<-82f){
                if(currentX>-160f&&currentX<-18f){
                    if (Input.GetMouseButtonDown(0)){
                        Buy.SetActive(false);
                        Buying=false;
                        Shopping=true;
                        
                    }
                }
                if(currentX>40f&&currentX<185f){
                    if (Input.GetMouseButtonDown(0)){
                        Buy.SetActive(false);
                        Buying=false;
                        
                        if(BuyInt==0){
                            if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt<1){
                                UiObject.SetActive(true);
                                UiText.text="칩이 모자랍니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f));
                                ChipSetBuy.SetActive(false);
                            }else{
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt-=1;
                                StartConversation();
                                Cursur.SetActive(false);
                                Shopping=false;
                                ChipSetBuy.SetActive(false);
                                IfBuy=true;
                            }
                            
                        }else if(BuyInt==1){
                            if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().Upgrade==true){
                                UiObject.SetActive(true);
                                UiText.text="더이상은 구매할 수 없습니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                UpgradeBuy.SetActive(false);
                            }else if(Chip<4){
                                UiObject.SetActive(true);
                                UiText.text="칩이 모자랍니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                UpgradeBuy.SetActive(false);
                            }else{
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt-=4;
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().Upgrade=true;
                                UpgradeBuy.SetActive(false);
                                IfBuy=true;
                            }
                            
                        }else if(BuyInt==2){
                            if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().HealKit>=5){
                                UiObject.SetActive(true);
                                UiText.text="더이상은 구매할 수 없습니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                HealKitBuy.SetActive(false);
                            }else if(Chip<1){
                                UiObject.SetActive(true);
                                UiText.text="칩이 모자랍니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                HealKitBuy.SetActive(false);
                            }else{
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt-=1;
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().HealKit+=1;
                                HealKitBuy.SetActive(false);
                                IfBuy=true;
                            }
                        }else if(BuyInt==3){
                            if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().FakeBody>=3){
                                UiObject.SetActive(true);
                                UiText.text="더이상은 구매할 수 없습니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                FakeBodyBuy.SetActive(false);
                            }else if(Chip<2){
                                UiObject.SetActive(true);
                                UiText.text="칩이 모자랍니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                FakeBodyBuy.SetActive(false);
                            }else{
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt-=1;
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().FakeBody+=1;
                                FakeBodyBuy.SetActive(false);
                                IfBuy=true;
                            }
                        }else if(BuyInt==4){
                            if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().HealKit>=2){
                                UiObject.SetActive(true);
                                UiText.text="더이상은 구매할 수 없습니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                EmpBuy.SetActive(false);
                            }else if(Chip<3){
                                UiObject.SetActive(true);
                                UiText.text="칩이 모자랍니다.";
                                StartCoroutine(ExecuteAfterDelayText(3f)); 
                                EmpBuy.SetActive(false);
                            }else{
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().ChipInt-=1;
                                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().Emp+=1;
                                EmpBuy.SetActive(false);
                                IfBuy=true;
                            }
                        }
                        Shopping=true;
                        Cursur.SetActive(true);
                    }
                }
                
            }

        }
        
    }

    public void StartConversation(){
        if(!Conversation){
            player.GetComponent<GunInventory>().ChangeWeapon1();
            isTalking=true;
            curResponseTracker=0;
            dialogueUI.SetActive(true);
            npcName.text="이선생";
            if(Stage==0){npcDialogueBox.text=dialogue[0];}
            if(Stage==1){npcDialogueBox.text=dialogue1[0];}
            if(Stage==2){npcDialogueBox.text=dialogue2[0];}
            if(Stage==3){npcDialogueBox.text=dialogue3[0];}
            if(Stage==4){npcDialogueBox.text=dialogue4[0];}
            if(Stage==5){npcDialogueBox.text=dialogue5[0];}
            player.GetComponent<MouseLookScript>().enabled = false;
            player.GetComponent<PlayerMovementScript>().enabled = false;
        
        }
            


    }


    public void ContinueConversation(){
            curResponseTracker++;
            if(Stage==0){
                if(curResponseTracker>dialogue.Length){
                    curResponseTracker=dialogue.Length;
                }
                else if(curResponseTracker<dialogue.Length)
                {
                    npcDialogueBox.text=dialogue[curResponseTracker];
                }
            }else if(Stage==1){
                if(curResponseTracker>dialogue1.Length){
                    curResponseTracker=dialogue1.Length;
                }
                else if(curResponseTracker<dialogue1.Length)
                {
                    npcDialogueBox.text=dialogue1[curResponseTracker];
                }
            }else if(Stage==2){
                if(curResponseTracker>dialogue2.Length){
                    curResponseTracker=dialogue2.Length;
                }
                else if(curResponseTracker<dialogue2.Length)
                {
                    npcDialogueBox.text=dialogue2[curResponseTracker];
                }
            }else if(Stage==3){
                if(curResponseTracker>dialogue3.Length){
                    curResponseTracker=dialogue3.Length;
                }
                else if(curResponseTracker<dialogue3.Length)
                {
                    npcDialogueBox.text=dialogue3[curResponseTracker];
                }
            }else if(Stage==4){
                if(curResponseTracker>dialogue4.Length){
                    curResponseTracker=dialogue4.Length;
                }
                else if(curResponseTracker<dialogue4.Length)
                {
                    npcDialogueBox.text=dialogue4[curResponseTracker];
                }
            }else if(Stage==5){
                if(curResponseTracker>dialogue5.Length){
                    curResponseTracker=dialogue5.Length;
                }
                else if(curResponseTracker<dialogue5.Length)
                {
                    npcDialogueBox.text=dialogue5[curResponseTracker];
                }
            }
            
    }

    public void EndDialogue(){
        Chip=player.GetComponent<PlayerMovementScript>().ChipInt;
        curResponseTracker=0;
        isTalking=false;
        dialogueUI.SetActive(false);
        if(Stage==3){
            Shopping=true;
            Cursur.SetActive(true);
            
        }
        /*
        QuestActive();
        if(Stage==0){
            QuestActive();
            player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
        }
        */
        if(Stage==2){
            QuestActive();
            if(Stage==0){
                QuestActive();
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
            }
        }
        if(Stage==0||Stage==1){
            if(Chip==0){Stage=2;StartConversation();}
            else{Stage=3;OpenShop();}
        }
        if(Stage==4){
            Cursur.SetActive(true);
            ShopUi.SetActive(true);
            Shopping=true;
            Buying=false;
            uiRectTransform.anchoredPosition = new Vector2(0, 0);
        }
        if(Stage==5){
            
            QuestActive();
            player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
        }
        
        
        
        
    }
    public void QuestActive(){
        Text.text="건물내부로 잠입하라.";
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
    public void OpenShop(){
        ShopUi.SetActive(true);
        Shopping=true;
        Cursur.SetActive(true);
    }
    public void GiveChipSet(){

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            Stage=1;
            StartConversation();
            
        }
    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        UiObject.SetActive(false);
        
    }
    private IEnumerator AfterBuying(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        Buying=true;
        
    }
}

