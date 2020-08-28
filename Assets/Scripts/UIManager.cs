using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //COINS
    [SerializeField]
    private Text _coinsText;
    //LIVES
    [SerializeField]
    private Text _livesText;


    //This funcion gets the number of coins from the player class and displays it.
    public void UIcoins(int updatecoins)
    {
        _coinsText.text = "Coins :" + updatecoins;
    }

    public void LivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }

}
