using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;

public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] PlayerModel model;

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

    private void UpdateHp(int hp)
    {
        sb.Clear();
        sb.Append(hp);
        hpText.SetText(sb);
    }
}
