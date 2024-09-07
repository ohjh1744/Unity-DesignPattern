using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class MVPController : MonoBehaviour
{
    [SerializeField] TextMeshPro hpText;
    [SerializeField] PlayerModel model;
    // Update is called once per frame
    private StringBuilder sb = new StringBuilder();

    private void OnEnable()
    {
        model.OnHpChanged += UpdateHp;
    }

    private void OnDisable()
    {
        model.OnHpChanged -= UpdateHp;
    }

    private void Start()
    {
        UpdateHp(model.Hp);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            model.Hp += 10;
        }
    }

    private void UpdateHp(int hp)
    {
        sb.Clear();
        sb.Append(hp);
        hpText.SetText(sb);
    }
}
