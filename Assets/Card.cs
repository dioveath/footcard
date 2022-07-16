using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Card : MonoBehaviour
{
    
    void Update(){

        // check if the card is being clicked
        if(Input.GetMouseButtonDown(0)){
            Vector3 worldPos = transform.TransformPoint(transform.position);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            
            // print screnPos to console
            Debug.Log(screenPos);
        }
        
    }
}
