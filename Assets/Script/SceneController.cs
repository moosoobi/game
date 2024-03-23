using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;  // 다음으로 넘어갈 씬의 이름

    public VideoPlayer videoPlayer;


    private void Start()
    {
        // 비디오 플레이어의 재생이 끝나면 OnVideoEnd 함수를 호출하도록 설정
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        LoadNextScene();
    }
    // 다음 씬으로 넘어가는 함수
    public void LoadNextScene()
    {
        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneName);
    }
}
