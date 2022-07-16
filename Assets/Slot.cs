using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Card _card;
    
    public void PlaceCard(Card card){
        _card = card;
        _card.transform.parent = transform;
        _card.transform.localPosition = Vector3.zero;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Collision");
        if(other.gameObject.tag == "Card"){
            Card card = other.gameObject.GetComponent<Card>();
            if(card != null){
                PlaceCard(card);
            }
        }
    }
    

}
