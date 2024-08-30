using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager 
{
    public static GameManager Game { get { return GameManager.Instance; } }
    
    //���� �����ϸ� �ٸ��ͺ��� ���� ���� ȣ��� �Լ�
    //�뵵: ���� ����, �̱��� ����, ��
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //���Ӽ��� ����

        //�̱��� ����
        GameManager.Create();
    }
 
}
