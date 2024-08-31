using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdapter : MonoBehaviour, IInteractable
{
    //�����Ȳ������ Player�� ���� ����Ǳ��� 
    public UnityEvent<Player> OnInteract;

    public void TargetInteract(Player player)
    {
        OnInteract?.Invoke(player);
    }
  
}
