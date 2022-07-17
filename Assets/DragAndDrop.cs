using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public RectTransform rectTransform;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    private Vector3 initialPosition;

    void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start(){
        initialPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;        
        canvasGroup.alpha = 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;        
        canvasGroup.alpha = 1f;
        rectTransform.anchoredPosition = initialPosition;
    }

}
