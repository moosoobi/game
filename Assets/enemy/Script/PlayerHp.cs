using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHp : MonoBehaviour
{
    public float PlayerCurHp=100f;
    public float PlayerMaxHp=100f;
    public Slider healthSlider;
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
    public TextMeshProUGUI Core;
    public Slider CorehealthSlider;
    public AudioSource UrgentSound;
    public AudioSource BarBackground;


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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UrgentSound.Stop();
            BarBackground.Play();
            CorehealthSlider.gameObject.SetActive(false);
            Core.gameObject.SetActive(false);
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
            player.transform.position=new Vector3(351f, -3.8f, 430f);
            player.transform.rotation=Quaternion.Euler(new Vector3(0f, 0f, 0f));
            PlayerCurHp=100f;
            player.GetComponent<MouseLookScript>().enabled = true;
            player.GetComponent<PlayerMovementScript>().enabled = true;
            GameOver.SetActive(false);

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

        // 현재 HP 갱신
        PlayerCurHp += newHP;

        // 슬라이더에 반영
        healthSlider.value = PlayerCurHp;

        // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
        if (PlayerCurHp <= 0f)
        {
            // 추가적인 처리 (보스 사망 등)
            PlayerDefeated();
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
    private IEnumerator Death()
    {

        yield return new WaitForSeconds(2.0f);
        Player.enabled=false;
        yield return new WaitForSeconds(1.0f);
        GameOver.SetActive(true);
        Die=true;
        
    }
}
