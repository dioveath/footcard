using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Card card = GetComponent<Card>();
            if (card.mode == CardMode.ATTACK)
            {
                card.ChangeMode(CardMode.DEFENSE);
            }
            else
            {
                card.ChangeMode(CardMode.ATTACK);
            }
        }
    }
}
