using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //COINS
    [SerializeField]
    private Text _coinsText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This funcion gets the number of coins from the player class and displays it.
    public void UIcoins(int updatecoins)
    {
        _coinsText.text = "Coins :" + updatecoins;
    }

}
