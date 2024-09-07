using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MVPModel : MonoBehaviour
{
    [SerializeField] private int hp;

    public int Hp { get { return hp; } set { hp = value; OnHpChanged?.Invoke(hp); } }
    public UnityAction<int> OnHpChanged;
}
