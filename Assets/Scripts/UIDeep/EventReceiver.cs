using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventReceiver : MonoBehaviour
    , IPointerClickHandler 
    , IPointerEnterHandler 
    , IPointerExitHandler
    , IPointerUpHandler
    , IPointerDownHandler
    , IPointerMoveHandler
    , IBeginDragHandler
    , IEndDragHandler
    , IDragHandler
    , IDropHandler
{
    public event UnityAction<PointerEventData> OnClicked;
    public event UnityAction<PointerEventData> OnEntered;
    public event UnityAction<PointerEventData> OnExited;
    public event UnityAction<PointerEventData> OnUped;
    public event UnityAction<PointerEventData> OnDowned;
    public event UnityAction<PointerEventData> OnMoved;
    public event UnityAction<PointerEventData> OnBeginDraged;
    public event UnityAction<PointerEventData> OnEndDraged;
    public event UnityAction<PointerEventData> OnDraged;
    public event UnityAction<PointerEventData> OnDroped;

    //
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEntered?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExited?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUped?.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDowned?.Invoke(eventData);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        OnMoved?.Invoke(eventData);
    }

    // 1.drag 이벤트를 사용해 물체 드래그 이동 구현 주석처리부분. Invoke는 UIbinding을 위함.
    //Vector3 pos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDraged?.Invoke(eventData);
        //pos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDraged?.Invoke(eventData);
        //Plane plane = new Plane(Vector3.up, pos);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if(plane.Raycast(ray, out float distance))
        //{
        //    transform.position = ray.GetPoint(distance);
        //}
        // 단순히 x, y 좌표만 이용하여 이동할때
        //transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDraged?.Invoke(eventData);
        //transform.position = Vector3.pos;
    }


    public void OnDrop(PointerEventData eventData)
    {
        OnDroped?.Invoke(eventData);
    }
}
