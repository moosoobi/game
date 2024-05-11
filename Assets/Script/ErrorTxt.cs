using System;
using System.IO;
using UnityEngine;

public class ErrorTxt : MonoBehaviour
{
    private string logFilePath;

    private void Start()
    {
        // 빌드된 애플리케이션 폴더 내에 ErrorLog.txt 파일 생성
        logFilePath = Application.dataPath + "/ErrorLog.txt";

        // 파일이 이미 존재하는 경우에는 덮어쓰지 않고 추가합니다.
        File.AppendAllText(logFilePath, "Error Log - " + DateTime.Now.ToString() + "\n");
    }

    private void OnEnable()
    {
        // 오류 발생 시 호출되는 Unity 이벤트 함수
        Application.logMessageReceived += LogError;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= LogError;
    }

    private void LogError(string logString, string stackTrace, LogType type)
    {
        // 오류 로그만 처리
        if (type == LogType.Error || type == LogType.Exception)
        {
            // 로그를 파일에 추가
            File.AppendAllText(logFilePath, type.ToString() + ": " + logString + "\n" + stackTrace + "\n\n");
        }
    }
}
