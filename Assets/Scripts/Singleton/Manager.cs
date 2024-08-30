using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager 
{
    public static GameManager Game { get { return GameManager.Instance; } }
    
    //게임 시작하면 다른것보다 가장 먼저 호출될 함수
    //용도: 게임 설정, 싱글톤 생성, 등
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //게임설정 진행

        //싱글톤 생성
        GameManager.Create();
    }
 
}
