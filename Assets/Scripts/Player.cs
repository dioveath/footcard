using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string playerName;
    public int endurance = 100;
    public Deck deck;
    public Button[] buttons;
    public CardField field;
    public CardField battleField;
    
    public int availableDraws = 1;

    
    public void GainTurn(){
        availableDraws = 1;
        foreach(Button button in buttons){
            button.interactable = true;
        }
    }

    public void DrawCard(){
        if(availableDraws <= 0) { 
            Debug.Log("No draws left!");
            return;
        }


        if(deck.cards.Count > 0 && field.cards.Count < field.maxCards){
            Card card = deck.DrawCard();
            field.AddCard(card);
            availableDraws--;            
            if(availableDraws <= 0) { 
                foreach(Button button in buttons) {
                    button.interactable = false;
                }
            }
        } else { 
            Debug.Log("Fields full!");
        }
    }

    public void AttackOpponent(Player player){
        if(availableDraws <= 0) { 
            Debug.Log("No draws left!");
            return;
        }
        
        int totalAttack = 0;
        foreach(Card card in battleField.cards){
            if(card.mode == CardMode.ATTACK){
                totalAttack += card.data.attack;
            }
        }

        int totalDefense = 0;
        foreach(Card card in player.field.cards){
            if(card.mode == CardMode.DEFENSE){
                totalDefense += card.data.defense;
            }
        }
        
        int damage = totalAttack - totalDefense;

        if(damage < 0) damage = 0;
        player.endurance -= damage;
        if(player.endurance <= 0) player.endurance = 0;

        availableDraws--;
        if(availableDraws <= 0) { 
            foreach(Button button in buttons) {
                button.interactable = false;
            }
        }
    }

    public void ShuffleCards(){
        deck.ShuffleCards();        
    }

    public void EndTurn(){
        MatchManager.Instance.ChangeTurn();
    }
    
}
