using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button btnDiemdanh;
    public GameObject Dailybonus;
    void Start()
    {
        btnDiemdanh.onClick.AddListener(_showDailybonus);
    }
    private void Update()
    {
        ActiveBtnDiemDanh();
    }


    public void _showDailybonus()
    {
        Dailybonus.SetActive(true);
    }    

    public void ActiveBtnDiemDanh()
    {
        if(DailyBonusMange.CheckTime())
        { btnDiemdanh.gameObject.SetActive(true); }   
        else
        {
            btnDiemdanh.gameObject.SetActive(false);
        }    
        
    }    

}
