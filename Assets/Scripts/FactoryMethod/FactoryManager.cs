using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType { 오크, 좀비}
public class FactoryManager : MonoBehaviour
{
    public List<MonsterFactory> MonsterFactory;

    private Dictionary<MonsterType, MonsterFactory> _monsterFactoriesByType;

    private void Start()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        _monsterFactoriesByType = new Dictionary<MonsterType, MonsterFactory>();
        for (int i = 0; i < MonsterFactory.Count; i++)
        {
            _monsterFactoriesByType[(MonsterType)i] = MonsterFactory[i];
        }
    }

    public Monster CreateMonsterbasedOnType(MonsterType monsterType)
    {
        if(_monsterFactoriesByType.TryGetValue(monsterType, out MonsterFactory factory))
        {
            return factory.Create();
        }
        return null;
    }
}
