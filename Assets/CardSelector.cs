using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour, IPointerDownHandler
{

    public Sprite[] sprites;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // change the sprite according to cardmode
            Card card = GetComponent<Card>();
            if (card.mode == CardMode.ATTACK)
            {
                card.mode = CardMode.DEFENSE;
                GetComponent<Image>().sprite = sprites[1];
            }
            else
            {
                card.mode = CardMode.ATTACK;
                GetComponent<Image>().sprite = sprites[0];
            }
        }
    }
}
