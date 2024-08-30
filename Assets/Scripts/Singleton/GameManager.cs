using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // ���α׷� ��𿡼��� ������ �� �ִ� �������� �������� ����
    public static GameManager Instance { get; private set; }

    public int score;

    public event UnityAction OnStarted;
    public event UnityAction OnPaused;
    public event UnityAction OnResumed;
    public event UnityAction OnFinished;

    // �� �ϳ��� �ν��Ͻ��� ����
    private void Awake()
    {
        // Awake : ó�� ��������� �� ȣ��Ǵ� �Լ�
        // �̱����� �������� => ���� ���� �ν��Ͻ��� �̱������� ����
        if (Instance == null)
        {
            Instance = this;

            // ���ο� ����ȯ(�ε�)������ �������� �ʴ� ���ӿ�����Ʈ�� �����
            DontDestroyOnLoad(gameObject);
        }
        // �̱����� �־����� => ���� ���� �ν��Ͻ��� ��������
        else  // if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // �̱��� �����
    public static void Create()
    {
        // Resources ���� : ����Ƽ�� Ư�������� Resources �������� ������ �ڵ� ��θ� ���ؼ� �ε� ����
        // ��, Resources ������ ��������� �ݵ�� ���ԵǴ� �������� �з��ǹǷ� ���Ӻ��������� ũ�⸦ ������Ŵ
        // ����, ������ �Ը� �۰ų� ���ҽ��� ���� ���� �� ��� ���� (���� 6���� �̸��� �������� ������� ��õ)
        // ����, ���¹����̳� ��巹������ ���ؼ� ������ �ʿ䰡 ����

        // Resources.Load<T>(path) : Resources ���� ���� ��ο��� ������ ã�� ������
        GameManager gameManagerPrefab = Resources.Load<GameManager>("Managers/GameManager");
        Instantiate(gameManagerPrefab);
    }

    // �̱��� �����
    public static void Release()
    {
        if (Instance == null)
            return;

        Destroy(Instance.gameObject);
        Instance = null;
    }
}
