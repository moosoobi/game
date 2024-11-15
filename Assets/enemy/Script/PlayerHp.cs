using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHp : MonoBehaviour
{
    public float PlayerCurHp;
    public float PlayerMaxHp;
    public Slider healthSlider;
    public GameObject HpOver;
    public GameObject GameOver;
    public Animator Player;
    public GameObject player;
    public Leg2RobotBlue Blue1;
    public Leg2RobotBlue Blue2;
    public Leg2RobotRed Red1;
    public Leg2RobotRed Red2;
    public Leg4Robot Leg1;
    public Leg4Robot Leg2;
    public Leg4Robot Leg3;
    public Leg4Robot Leg4;
    public EnergyCore Energy;
    public bool first=true;
    public bool Die=false;

    public Slider CorehealthSlider;
    public AudioSource UrgentSound;
    public AudioSource BarBackground;
    public int stage=0;
    public GameObject HitImage;
    public RealBoss Boss;

    void Start()
    {
        InitializeHealthBar();
        
    }


    void Update()
    {
    if (PlayerCurHp <= 0f)
    {
        if(first){
            UpdateHealth(0);
            first=false;
        }
        
    }
    if(Die){
        if(stage==0){
            if (Input.GetKeyDown(KeyCode.Return))
            {
                UrgentSound.Stop();
                HpOver.SetActive(true);
                CorehealthSlider.gameObject.SetActive(false);
                
                Blue1.Respawn();
                Blue2.Respawn();
                Red1.Respawn();
                Red2.Respawn();
                Leg1.Respawn();
                Leg2.Respawn();
                Leg3.Respawn();
                Leg4.Respawn();
                Energy.Respawn();
                Die=false;
                player.transform.position=new Vector3(371f, -3.85f, 432.7f);
                player.transform.rotation=Quaternion.Euler(new Vector3(0f, 90f, 0f));
                PlayerCurHp=1000f;
                UpdateHealth(0);
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
                GameOver.SetActive(false);

            }
        }else if(stage==1){
            if (Input.GetKeyDown(KeyCode.Return))
            {
                HpOver.SetActive(true);
                Die=false;
                player.transform.position=new Vector3(386f, 0.7f, 413.8f);
                player.transform.rotation=Quaternion.Euler(new Vector3(0f, 0f, 0f));
                PlayerCurHp=1000f;
                UpdateHealth(0);
                GameOver.SetActive(false);
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
            }
        }else if(stage==2){
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Die=false;
                player.transform.position=new Vector3(21.1f, 258.8f, 432.15f);
                player.transform.rotation=Quaternion.Euler(new Vector3(0f, -90f, 0f));
                PlayerCurHp=1000f;
                UpdateHealth(0);
                HpOver.SetActive(true);
                GameOver.SetActive(false);
                player.GetComponent<MouseLookScript>().enabled = true;
                player.GetComponent<PlayerMovementScript>().enabled = true;
                Boss.ReStart();
                
            }
        }
        
    }
    
}

    void InitializeHealthBar()
    {
        // 최대 HP 설정
        healthSlider.maxValue = PlayerMaxHp;

        // 현재 HP 설정
        healthSlider.value = PlayerCurHp;
    }
    public void UpdateHealth(float newHP)
    {
        if(!Die){
            // 현재 HP 갱신
            PlayerCurHp += newHP;
            if(PlayerCurHp>=1000){PlayerCurHp=1000;}
            // 슬라이더에 반영
            healthSlider.value = PlayerCurHp;
            if(newHP!=0){StartCoroutine(Hit());}
            // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
            if (PlayerCurHp <= 0f)
            {
                // 추가적인 처리 (보스 사망 등)
                PlayerDefeated();
                HpOver.SetActive(false);
                Die=true;
            }
        }
        
    }

    void PlayerDefeated()
    {
        
        StartCoroutine(Death());
        Player.enabled=true;
        Player.Play("PlayerDeath", 0, 0.0f);
        player.GetComponent<MouseLookScript>().enabled = false;
        player.GetComponent<PlayerMovementScript>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("PlayerAttack10")){
                UpdateHealth(-10f);
            }
            if (other.CompareTag("PlayerAttack20")){
                UpdateHealth(-20f);
            }
            if (other.CompareTag("PlayerAttack30")){
                UpdateHealth(-30f);
            }
        
        
        
    }
    private IEnumerator Hit(){
        HitImage.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        HitImage.SetActive(false);
    }
    private IEnumerator Death()
    {

        yield return new WaitForSeconds(2.0f);
        Player.enabled=false;
        yield return new WaitForSeconds(1.0f);
        GameOver.SetActive(true);
        
        
    }
}
