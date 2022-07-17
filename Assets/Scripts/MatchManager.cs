using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{

    public Player player1;
    public Player player2;

    public bool isPlayer1Turn = true;
    public Card selectedCard;

    public static MatchManager Instance;

    public GameObject WinUI;
    public Text winText;


    void Awake()
    {
        Instance = this;
        WinUI.SetActive(false);
    }

    void Start(){
        player1.deck.LoadDeck();
        player1.deck.ShuffleCards();        
        player2.deck.LoadDeck();
        player2.deck.ShuffleCards();         
    }

    void Update(){
        if(player1.endurance <= 0){
            winText.text = "You lose!";
            WinUI.SetActive(true);
        } else if(player2.endurance <= 0){
            winText.text = "You win!";
            WinUI.SetActive(true);            
        }
    }

    public void ChangeTurn()
    {
        isPlayer1Turn = !isPlayer1Turn;

        if (isPlayer1Turn)
        {
            player1.GainTurn();
        }
        else
        {
            player2.GainTurn();
            StartCoroutine(PlayerTwoTurn());
        }
        
    }

    public IEnumerator PlayerTwoTurn()
    {
        yield return new WaitForSeconds(1f);

        float random = Random.Range(0f, 1f);
        if (random < 0.5f && player2.battleField.cards.Count > 0)
        {
            player2.AttackOpponent(player1);
        } else { 
            player2.DrawCard();

                if(player2.battleField.cards.Count < player2.battleField.maxCards){
                                for(int i = player2.field.cards.Count - 1; i >= 0; i--)
                {
                    Card card = player2.field.cards[i];
                    card.RemoveFromField();
                    player2.battleField.AddCard(card);

                    if (card.data.attack > card.data.defense)
                    {
                        card.ChangeMode(CardMode.ATTACK);
                    }
                    else
                    {
                        card.ChangeMode(CardMode.DEFENSE);
                    }
                    
                }
                } else {
                    Debug.Log("Fields full!");
                }
            
        }

        ChangeTurn();
    }

}
