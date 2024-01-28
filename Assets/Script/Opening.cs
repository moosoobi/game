using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public string[] storySentences;
    private int currentSentenceIndex = 0;
    public SceneController sceneController;

    void Update()
    {
        // Z 키를 누를 때마다 다음 텍스트로 넘어가기
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentSentenceIndex < storySentences.Length)
            {
                // 텍스트 변경
                storyText.text = storySentences[currentSentenceIndex];
                
                // 다음 문장으로 인덱스 증가
                currentSentenceIndex++;

            }
            else
            {
                sceneController.LoadNextScene();
            }
        }
    }
}
