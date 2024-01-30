using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpbar : MonoBehaviour
{
    static public float BossHp=100f;
    public float BossMaxHp=100f;
    public Slider healthSlider;
    public Boss boss;

    void Start()
    {
        boss=GetComponent<Boss>();
        InitializeHealthBar();
    }

    void InitializeHealthBar()
    {
        // 최대 HP 설정
        healthSlider.maxValue = BossMaxHp;

        // 현재 HP 설정
        healthSlider.value = BossHp;
    }
    public void UpdateHealth(float newHP)
    {

        // 현재 HP 갱신
        BossHp += newHP;

        // 슬라이더에 반영
        healthSlider.value = BossHp;

        // HP가 0 이하로 떨어졌을 때 처리 (예를 들어, 보스가 죽었을 때)
        if (BossHp <= 0f)
        {
            // 추가적인 처리 (보스 사망 등)
            BossDefeated();
        }
    }

    void BossDefeated()
    {
        boss.die();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack")){
            UpdateHealth(-1f);
        }
        
    }
    
}
