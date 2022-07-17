using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{

    public GameObject cardPrefab;
    public Canvas canvas;

    public List<CardData> cardDatas = new List<CardData>();    
    public List<Card> cards = new List<Card>();




    public void LoadDeck(){
        cards.Clear();
        foreach (CardData data in cardDatas)
        {
            GameObject cardGO = GameObject.Instantiate(cardPrefab);
            Card card = cardGO.GetComponent<Card>();
            card.data = data;
            card.GetComponent<DragAndDrop>().canvas = canvas;
            card.mode = CardMode.DECK;
            cards.Add(card);
        }
    }
    
    public void ShuffleCards(){
        for(int i = 0; i < cards.Count; i++){
            int randomIndex = Random.Range(0, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card DrawCard(){
        Debug.Log("drawing card!");
            if(cards.Count > 0){
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            } else { 
                return null;
            }
    }

}
