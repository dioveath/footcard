using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public int endurance = 1000;
    public Deck deck;
    public CardField field;
    

    public void DrawCard(){
        
        if(deck.cards.Count > 0 && field.cards.Count < field.maxCards){
            Card card = deck.DrawCard();
            field.AddCard(card);
        } else { 
            Debug.Log("Fields full!");
        }
    }

    public void ShuffleCards(){
        deck.ShuffleCards();        
    }
    
    
}
