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
    public Button button;

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        player1.deck.LoadDeck();
        player1.deck.ShuffleCards();        
        player2.deck.LoadDeck();
        player2.deck.ShuffleCards();                
    }   

    public void ChangeTurn()
    {
        isPlayer1Turn = !isPlayer1Turn;
        if(isPlayer1Turn)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;            
            StartCoroutine(PlayerTwoTurn());
        }
    }

    public IEnumerator PlayerTwoTurn()
    {
        yield return new WaitForSeconds(1f);
        player2.DrawCard();
    }

}
