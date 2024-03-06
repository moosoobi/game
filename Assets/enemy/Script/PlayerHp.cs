using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public float PlayerCurHp=100f;
    public float PlayerMaxHp=100f;
    public Slider healthSlider;

    void Start()
    {
        InitializeHealthBar();
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
}
