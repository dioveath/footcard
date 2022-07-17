using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int health;
    public CardMode mode;
    public CardData data;
    public Image image;
    public Text nameText;
    public Text description;
    public Text enduranceText;
    public Text attackText;
    public Text defenseText;

    public CardField field;

    public Image cardBackImage;
    public Sprite[] sprites;    



    void Start(){
        health = data.endurance;
        image.sprite = data.artwork;
        nameText.text = data.name;
        description.text = data.description;
        enduranceText.text = data.endurance.ToString();
        attackText.text = data.attack.ToString();
        defenseText.text = data.defense.ToString();
        cardBackImage = GetComponent<Image>();
    }

    public void RemoveFromField(){
        if(field != null){
            field.RemoveCard(this);
        }
    }

    public void ChangeMode(CardMode mode){
        this.mode = mode;
        if(mode == CardMode.ATTACK){
            cardBackImage.sprite = sprites[0];
        } else {
            cardBackImage.sprite = sprites[1];
        }
    }

}

public enum CardMode {
    ATTACK,
    DEFENSE,
    INHAND,
    DECK
}
