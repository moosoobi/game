using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Boss : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public GameObject Text1;
    private int currentPatternIndex = 0; // 현재 실행 중인 공격 패턴 인덱스
    private bool isAttacking = false; // 현재 공격 중인지 여부
    public float duration=5f;
    public int AttackLength=3;
    public GameObject player;
    public GameObject PlayerForward;
    public GameObject flash;
    public AudioSource flashsound;
    void Update()
    {
        
        if (!isAttacking)
        {
            // 현재 공격 패턴 실행
            StartCoroutine(ExecuteAttackPattern());
        }
    }

    IEnumerator ExecuteAttackPattern()
    {
        isAttacking = true;

        // 현재 공격 패턴 실행
        if (currentPatternIndex < AttackLength)
        {
            

            // 공격 패턴 실행
            yield return StartCoroutine(Execute(currentPatternIndex));

            // 다음 패턴으로 이동
            currentPatternIndex++;
        }
        else
        {
            // 모든 패턴이 실행된 경우 초기화 또는 다른 동작 수행
            // 예: currentPatternIndex를 0으로 초기화
            currentPatternIndex = 0;
        }

        isAttacking = false;
    }

    public void LightAttack(){

        player = GameObject.FindGameObjectWithTag("Player");
        PlayerForward=GameObject.FindGameObjectWithTag("Forward");
        if (player != null)
        {
            
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 Player = (player.transform.position - PlayerForward.transform.position).normalized;
            float dotProduct = Vector3.Dot(Player, directionToPlayer);
            
            if (dotProduct > 0f)
            {
                player.GetComponent<HpBar>().healthminus();
                flash.SetActive(true);
                flashsound.Play();
                StartCoroutine(ExecuteAfterDelay(3f));
            }
        }
    }

    public void ElecticAttack(){
        
    }

    public void BulletAttack(){
        
    }

    public IEnumerator Execute(int currentPatternIndex)
    {
        if(currentPatternIndex==0){
            Text1.SetActive(true);
            text1.text="빛 공격 준비!";
            StartCoroutine(ExecuteAfterDelayText(3f));
            yield return new WaitForSeconds(duration);
            LightAttack();
            yield return new WaitForSeconds(duration);
        }else if(currentPatternIndex==1){
            ElecticAttack();
            Text1.SetActive(true);
            text1.text="전기 공격 준비!";
            StartCoroutine(ExecuteAfterDelayText(3f));
            yield return new WaitForSeconds(duration);
        }else if(currentPatternIndex==2){
            Text1.SetActive(true);
            text1.text="총 공격준비!";
            StartCoroutine(ExecuteAfterDelayText(3f));
            yield return new WaitForSeconds(duration);
            BulletAttack();
            yield return new WaitForSeconds(duration);
        }

        

   

    }
    private IEnumerator ExecuteAfterDelayText(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        Text1.SetActive(false);
    }
    private IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        // 일정 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);
        flash.SetActive(false);
    }
    
    

}



