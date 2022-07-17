using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class CardField : MonoBehaviour 
{
    public List<Card> cards = new List<Card>();
    public int maxCards = 5;
    public string fieldName = "default";

    void Start(){
        GetComponent<GridLayoutGroup>().constraintCount = maxCards;
    }

    public void AddCard(Card card){
        cards.Add(card);
        card.transform.SetParent(transform);
        card.field = this;
    }    

    public void RemoveCard(Card card){
        cards.Remove(card);
        card.transform.SetParent(null);
        card.field = null;
    }
    
}
