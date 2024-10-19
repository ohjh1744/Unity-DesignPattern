using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//사용 예시
public class WinView : BaseUI
{
    private void Awake()
    {
        BindAll();
    }
    void Start()
    {
        GetUI<Text>("CoinText").text = "5000";
        GetUI<Button>("Button").onClick.AddListener(ButtonAction);

        AddEvent("ChestImage", EventType.BeginDrag, BeginDrag);
        AddEvent("ChestImage", EventType.EndDrag, EndDrag);
        AddEvent("ChestImage", EventType.Drag, Drag);
    }

    Vector3 pos;

    public void ButtonAction()
    {
        Debug.Log("hi");
    }
    public void BeginDrag(PointerEventData eventData)
    {
        pos = GetUI<Transform>("ChestImage").position;
    }

    public void EndDrag(PointerEventData eventData)
    {
        GetUI<Transform>("ChestImage").position = pos;
    }

    public void Drag(PointerEventData eventData)
    {
        GetUI<Transform>("CHestImage").position += (Vector3)eventData.delta;
    }
}
