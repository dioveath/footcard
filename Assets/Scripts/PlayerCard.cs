using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : Card
{

    public int attack;
    public int defense;

    
    public void Attack(PlayerCard target){
        mode = CardMode.ATTACK;
        if(target.defense > attack){
            health -= target.defense;
        } else {
            target.health -= attack;
        }
    }
    
}
