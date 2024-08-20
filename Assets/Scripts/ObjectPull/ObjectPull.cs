using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    public GameObject[] Monsters;
    private List<GameObject>[] _pools;

    private void Awake()
    {
        _pools = new List<GameObject>[Monsters.Length];
        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in _pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(Monsters[index], transform);
            _pools[index].Add(select);
        }

        return select;
    }
}
