using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZone : MonoBehaviour, IDropHandler
{
    public CardField field;

    void Awake(){
        field = GetComponent<CardField>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if(field.cards.Count < field.maxCards){
            Card card = eventData.pointerDrag.GetComponent<Card>();
            if(card != null){
                card.RemoveFromField();
                field.AddCard(card);
            }
        } else {
            Debug.Log("Fields full!");
        }

    }

}
