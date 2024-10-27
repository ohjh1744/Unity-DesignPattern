using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    public static GameManager Game { get { return GameManager.Instance; } }

    //게임 시작하면 다른것보다 가장 먼저 호출될 함수
    //용도: 게임 설정, 싱글톤 생성, 등
    //Manager 방식 말고도 Resources 폴더 내부에 프리펩으로 저장하는 방식도 좋음.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //GameObject.Instantiate(Resources.Load<GameManager>("Manager/GameManager"));
    }
}
