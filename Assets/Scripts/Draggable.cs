using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform rectTransform;
    public Canvas canvas;
    private bool isDragging = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponent<Canvas>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
            transform.position = canvas.transform.TransformPoint(pos);
        }
        Debug.Log("OnDrag");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        Debug.Log("OnPointerDown");
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        rectTransform.localPosition = Vector3.zero;
        Debug.Log("OnPointerUp");
    }
}
