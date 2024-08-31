using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdapter : MonoBehaviour, IInteractable
{
    //현재상황에서는 Player를 빼도 실행되긴함 
    public UnityEvent<Player> OnInteract;

    public void TargetInteract(Player player)
    {
        OnInteract?.Invoke(player);
    }
  
}
