using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    public static GameManager Game { get { return GameManager.Instance; } }

    //���� �����ϸ� �ٸ��ͺ��� ���� ���� ȣ��� �Լ�
    //�뵵: ���� ����, �̱��� ����, ��
    //Manager ��� ���� Resources ���� ���ο� ���������� �����ϴ� ��ĵ� ����.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //GameObject.Instantiate(Resources.Load<GameManager>("Manager/GameManager"));
    }
}
