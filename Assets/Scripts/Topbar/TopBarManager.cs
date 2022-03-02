using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarManager : MonoBehaviour
{
    private int gems ;
    private static int coins;
    public Text txtGems, txtCoins;
    private string KEY_COINS = "Addcoin";
    private string KEY_GEMS = "Addgem";

    private void Awake()
    {
        ShowTopBarTxT();
    }



    private void OnEnable()
    {
        GameEvent.AddRewar += AddRewar;
        
    }

    private void OnDisable()
    {
        GameEvent.AddRewar -= AddRewar;
       
    }




    public void AddRewar(int coin,int gem)
    {
        
        coins += coin;
        gems += gem;
        PlayerPrefs.SetInt(KEY_COINS, coins);
        PlayerPrefs.SetInt(KEY_GEMS, gems);
        ShowTopBarTxT();
        //Debug.Log(coins.ToString() + " || " + gems.ToString());

    }
 


    public void ShowTopBarTxT()
    {
        coins = PlayerPrefs.GetInt(KEY_COINS, 0);
        gems = PlayerPrefs.GetInt(KEY_GEMS, 0);
        txtCoins.text = coins.ToString();
        txtGems.text = gems.ToString();
    }
    


}
