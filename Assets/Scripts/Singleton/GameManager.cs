using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // 프로그램 어디에서도 접근할 수 있는 전역적인 접근점을 제공
    public static GameManager Instance { get; private set; }

    public int score;

    public event UnityAction OnStarted;
    public event UnityAction OnPaused;
    public event UnityAction OnResumed;
    public event UnityAction OnFinished;

    // 단 하나의 인스턴스를 보장
    private void Awake()
    {
        // Awake : 처음 만들어졌을 때 호출되는 함수
        // 싱글톤이 없었으면 => 지금 만든 인스턴스를 싱글톤으로 쓰자
        if (Instance == null)
        {
            Instance = this;

            // 새로운 씬전환(로딩)에서도 지워지지 않는 게임오브젝트로 만들기
            DontDestroyOnLoad(gameObject);
        }
        // 싱글톤이 있었으면 => 지금 만든 인스턴스를 삭제하자
        else  // if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // 싱글톤 만들기
    public static void Create()
    {
        // Resources 폴더 : 유니티의 특수폴더로 Resources 폴더안의 에셋은 코드 경로를 통해서 로딩 가능
        // 단, Resources 폴더는 빌드과정에 반드시 포함되는 에셋으로 분류되므로 게임빌드파일의 크기를 증가시킴
        // 따라서, 게임의 규모가 작거나 리소스가 많지 않을 때 사용 권장 (보통 6개월 미만의 게임제작 결과물에 추천)
        // 추후, 에셋번들이나 어드레서블을 통해서 관리할 필요가 있음

        // Resources.Load<T>(path) : Resources 폴더 안의 경로에서 에셋을 찾아 참조함
        GameManager gameManagerPrefab = Resources.Load<GameManager>("Managers/GameManager");
        Instantiate(gameManagerPrefab);
    }

    // 싱글톤 지우기
    public static void Release()
    {
        if (Instance == null)
            return;

        Destroy(Instance.gameObject);
        Instance = null;
    }
}
