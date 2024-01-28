using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;  // 다음으로 넘어갈 씬의 이름

    // 다음 씬으로 넘어가는 함수
    public void LoadNextScene()
    {
        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }
}
