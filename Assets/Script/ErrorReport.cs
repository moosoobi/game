using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorReport : MonoBehaviour
{


    private string errorMessage = ""; // 오류 메시지를 저장할 변수

    // 오류 메시지를 받아와서 errorMessage 변수에 저장하는 메서드
    public void SetErrorMessage(string message)
    {
        errorMessage = message;
    }

    // GUI 화면에 오류 메시지를 표시하는 메서드
    void OnGUI()
    {
        // 오류 메시지가 비어있지 않으면 GUI 화면에 텍스트로 표시
        if (!string.IsNullOrEmpty(errorMessage))
        {
            GUI.Label(new Rect(10, 10, Screen.width - 20, 100), errorMessage);
        }
    }
}

