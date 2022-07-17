using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public Text healthText;

    void Update(){
        healthText.text = GetComponent<Player>().endurance.ToString();
    }
}
